using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window : MetroForm
    {
        public static Window currentWindow;
        private Point InvisiblePoint;
        
        public Window()
        {
            InitializeComponent();
            currentWindow = this;
            this.ControlBox = false; // removes minimize, maximize and exit buttons
            this.Movable = false;
            this.Resizable = false;

            // Initializes the icon, loading the ICO and creating methods for hiding, showing
            // and closing the application
            IconAndDisplayInitialize();

            DisplayAnimation();
        }

        private void IconAndDisplayInitialize()
        {
            this.screenBounds = Screen.FromControl(this).Bounds;

            // Move the form outside the screen to prevent flashing when showing
            this.InvisiblePoint = new Point(screenBounds.Width, screenBounds.Height);
            this.Location = this.InvisiblePoint;
        }

        public static void Kill()
        {
            currentWindow.DisposeComponents();
            currentWindow.Dispose();
            currentWindow = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
