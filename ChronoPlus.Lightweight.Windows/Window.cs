﻿using System;
using System.Drawing;
using System.Windows.Forms;
using ChronoPlus.Lightweight.Windows.CoreManagers;
using MetroFramework.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window : MetroForm
    {
        public static Window currentWindow;
        private Point InvisiblePoint;
        private bool ManualControl;
        
        public Window(bool manual = false)
        {
            InitializeComponent();
            currentWindow = this;
            this.ControlBox = false; // removes minimize, maximize and exit buttons
            this.Movable = false;
            this.Resizable = false;

            SetNextRollTime();
            ScreenBoundsAndPointInitialize();
            
            // Config
            InitializeAllConfigValues();
            BindAllToggles();


            this.ManualControl = manual;

            if (!this.ManualControl)
            {
                DisplayPopUpAnimation();
                InitializeChronoComponents();
            }
        }

        private void ScreenBoundsAndPointInitialize()
        {
            this.screenBounds = Screen.FromControl(this).Bounds;

            // Move the form outside the screen to prevent flashing when showing
            this.InvisiblePoint = new Point(screenBounds.Width, screenBounds.Height);
            this.Location = this.InvisiblePoint;
        }

        public static void Kill()
        {
            try
            {
                currentWindow.SaveAllConfigValues();
                currentWindow.DisposeComponents();
                currentWindow.Dispose();
                currentWindow = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            } catch
            {

            }
        }
    }
}