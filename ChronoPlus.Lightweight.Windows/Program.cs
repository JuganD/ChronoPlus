using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using ChronoPlus.Lightweight.Windows.CoreManagers;
using Timer = System.Timers.Timer;

namespace ChronoPlus.Lightweight.Windows
{
    static class Program
    {
        public static readonly string ChronoLocation = AppDomain.CurrentDomain.BaseDirectory;

        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConfigManager configManager = new ConfigManager();
            configManager.LoadConfig();

            // Instantiate iconManager before timerManager -> icon needed for initial error messages
            IconManager iconManager = new IconManager();
            TimerManager timerManager = new TimerManager();

            // AutoUpdater initialization
            try
            {
                AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
                AutoUpdater.Start(PrivateConfiguration.UpdateUrl); // string URL to the zip file with the update
            }
            catch { }

            Application.Run();
        }

        private static void AutoUpdater_ApplicationExitEvent()
        {
            IconManager.icon.Dispose();
            Window.Kill();
            Application.Exit();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {

        }

        internal static void StartNewWindow()
        {
            try
            {
                new Window().Show();
            }
            catch
            {
            }
        }
    }
}
