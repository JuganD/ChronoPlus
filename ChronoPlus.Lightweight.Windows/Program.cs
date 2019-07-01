using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace ChronoPlus.Lightweight.Windows
{
    static class Program
    {
        public static readonly string ChronoLocation = AppDomain.CurrentDomain.BaseDirectory;
        public static NotifyIcon icon;
        private static ContextMenuStrip IconMenu;
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            icon = new NotifyIcon()
            {
                ContextMenu = new ContextMenu()
            };

            var iconExitMenuItem = icon.ContextMenu.MenuItems.Add("Exit");
            iconExitMenuItem.Click += NotifyIcon_CloseClicked;

            //IconMenu = new ContextMenuStrip();
            //var item = new ToolStripMenuItem("Exit");
            //item.Click += NotifyIcon_CloseClicked;
            //IconMenu.Items.Add(item);
            //IconMenu.AutoClose = true;

            icon.MouseClick += NotifyIcon_Click;

            // Initializing contextmenu and adding the button Exit to exit the program

            icon.Visible = true;

            if (File.Exists(Path.Combine(ChronoLocation, "Resources/icon.ico")))
            {
                Program.icon.Icon = new Icon(Path.Combine(ChronoLocation, "Resources/icon.ico"));
            }
            else
            {
                MessageBox.Show("Error! Mandatory file icon.ico not found.", "Error", MessageBoxButtons.OK);
                Window.Kill();
            }

            Application.Run();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            
        }

        private static void StartNewWindow()
        {
            try
            {
                new Window().Show();
            }
            catch
            {
            }
        }

        private static void NotifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Window.currentWindow != null)
                {
                    Window.Kill();
                }
                else
                {
                    StartNewWindow();
                }
            }
        }

        private static void NotifyIcon_CloseClicked(object sender, EventArgs e)
        {
            icon.Visible = false;
            icon.Dispose();
            if (Window.currentWindow != null && !Window.currentWindow.IsDisposed)
            {
                var bounds = Screen.FromControl(Window.currentWindow).Bounds;
                Window.currentWindow.Location = new Point(bounds.Width + 20, bounds.Height + 20);
                Window.currentWindow.Dispose();
            }

            Process.GetCurrentProcess().Kill();
        }
    }
}
