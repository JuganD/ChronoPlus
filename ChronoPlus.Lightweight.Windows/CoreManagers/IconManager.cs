using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class IconManager
    {
        public static NotifyIcon icon;

        public IconManager()
        {
            icon = new NotifyIcon()
            {
                ContextMenu = new ContextMenu()
            };

            var iconExitMenuItem = icon.ContextMenu.MenuItems.Add("Exit");
            iconExitMenuItem.Click += NotifyIcon_CloseClicked;

            icon.MouseClick += NotifyIcon_Click;

            // Initializing contextmenu and adding the button Exit to exit the program

            icon.Visible = true;

            if (File.Exists(Path.Combine(Program.ChronoLocation, "Resources/icon.ico")))
            {
                icon.Icon = new Icon(Path.Combine(Program.ChronoLocation, "Resources/icon.ico"));
            }
            else
            {
                MessageBox.Show("Error! Mandatory file icon.ico not found.", "Error", MessageBoxButtons.OK);
                Window.Kill();
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
                    Program.StartNewWindow();
                }
            }
        }

        private static void NotifyIcon_CloseClicked(object sender, EventArgs e)
        {
            try
            {
                icon.Visible = false;
                icon.Dispose();
                if (Window.currentWindow != null && !Window.currentWindow.IsDisposed)
                {
                    var bounds = Screen.FromControl(Window.currentWindow).Bounds;
                    Window.currentWindow.Location = new Point(bounds.Width + 20, bounds.Height + 20);
                    Window.currentWindow.Dispose();
                }
            } catch
            {

            }
            finally
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
