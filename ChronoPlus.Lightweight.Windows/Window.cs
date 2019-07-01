using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window : Form
    {
        private readonly string ChronoLocation = AppDomain.CurrentDomain.BaseDirectory;
        
        public Window()
        {
            InitializeComponent();

            // Initializes the icon, loading the ICO and creating methods for hiding, showing
            // and closing the application
            IconAndDisplayInitialize();


        }

        private void IconAndDisplayInitialize()
        {
            this.screenBounds = Screen.FromControl(this).Bounds;
            if (File.Exists(Path.Combine(this.ChronoLocation, "Resources/icon.ico")))
            {
                icon.Icon = new Icon(Path.Combine(this.ChronoLocation, "Resources/icon.ico"));
            }
            else
            {
                MessageBox.Show("Error! Mandatory file icon.ico not found.", "Error", MessageBoxButtons.OK);
                Process.GetCurrentProcess().Kill();
            }
            icon.MouseUp += NotifyIcon_Click;
            this.icon.ContextMenu = new ContextMenu();
            var iconExitMenuItem = this.icon.ContextMenu.MenuItems.Add("Exit");
            iconExitMenuItem.Click += NotifyIcon_CloseClicked;
            icon.Visible = true;
        }
        
    }
}
