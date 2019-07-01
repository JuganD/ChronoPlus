using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window : MetroForm
    {
        private readonly string ChronoLocation = AppDomain.CurrentDomain.BaseDirectory;
        private Point InvisiblePoint;
        
        public Window()
        {
            InitializeComponent();
            this.ControlBox = false; // removes minimize, maximize and exit buttons
            this.Movable = false;
            this.Resizable = false;

            // Initializes the icon, loading the ICO and creating methods for hiding, showing
            // and closing the application
            IconAndDisplayInitialize();

        }

        private void IconAndDisplayInitialize()
        {
            this.screenBounds = Screen.FromControl(this).Bounds;

            // Move the form outside the screen to prevent flashing when showing
            this.InvisiblePoint = new Point(screenBounds.Width, screenBounds.Height);
            this.Location = this.InvisiblePoint;

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

            // Initializing contextmenu and adding the button Exit to exit the program
            this.icon.ContextMenu = new ContextMenu();
            var iconExitMenuItem = this.icon.ContextMenu.MenuItems.Add("Exit");
            iconExitMenuItem.Click += NotifyIcon_CloseClicked;
            icon.Visible = true;
        }
        
    }
}
