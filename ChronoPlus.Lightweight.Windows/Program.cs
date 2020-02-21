using System;
using System.Threading;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using ChronoPlus.Lightweight.Windows.CoreManagers;

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

            // Instantiate iconManager before voteManager -> icon needed for initial error messages
            IconManager iconManager = new IconManager();
            VoteManager voteManager = new VoteManager();

            // AutoUpdater initialization
            try
            {
                if (!ConfigManager.Config.ContainsKey("DisableAutoUpdater") ||
                        (ConfigManager.Config.ContainsKey("DisableAutoUpdater") &&
                         ConfigManager.Config["DisableAutoUpdater"] != "true"))
                {
                    AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
                    AutoUpdater.Start(PrivateConfiguration.UpdateUrl); // string URL to the file with the update settings
                }
            }
            catch (Exception) // TODO: implement error folder through FileManager to log these errors
            {
                if (IconManager.icon != null)
                {
                    IconManager.BalloonTipClickedAction = delegate
                    {
                        if (!ConfigManager.Config.ContainsKey("DisableAutoUpdater"))
                        {
                            ConfigManager.Config.Add("DisableAutoUpdater", null);
                        }
                        ConfigManager.Config["DisableAutoUpdater"] = "true";
                    };
                    IconManager.icon.ShowBalloonTip(3000,
                        "Chrono+",
                        "Error! Could not initialize autoupdater. Click this message to disable AutoUpdater.",
                        ToolTipIcon.Error);
                }
            }

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
            catch {} 
            // Those errors should be handled at Window level, however if some of them make it here
            // they should not obstruct the application flow.
            // TODO: implement error log handler
        }
    }
}
