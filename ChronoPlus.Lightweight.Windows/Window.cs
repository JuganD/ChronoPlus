using System;
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

            TimeSpan t = TimeSpan.FromMilliseconds(TimerManager.GetRemainingTime());
            string time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);

            this.nextRollTime.Text = time;
            // Initializes the icon, loading the ICO and creating methods for hiding, showing
            // and closing the application
            ScreenBoundsAndPointInitialize();

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
