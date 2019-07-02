using System.ComponentModel;
using System.Drawing;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private bool AnimationGoing = false;
        private Rectangle screenBounds;

        public void ShowWindow()
        {
            this.Focus();
            this.Visible = true;
            this.Activate();
        }
        public void CloseWindow()
        {
            Window.Kill();
        }
        // Performs pop-up animation of the form
        public async Task DisplayPopUpAnimation(double speed = 30)
        {
            this.AnimationGoing = true;

            Point formPoint = new Point(screenBounds.Width - this.Width, screenBounds.Height);
            ShowWindow();
            this.Location = formPoint;
            int wantedHeight = screenBounds.Height - this.Height - 30; // taskbar height

            for (double i = screenBounds.Height; i >= wantedHeight; i -= speed)
            {
                formPoint.Y = (int)i;
                this.Location = formPoint;
                if (speed > 3)
                {
                    speed -= CalculateFluentAnimationSpeed(i, wantedHeight);
                }
                await Task.Delay(20);
            }

            this.Focus();
            this.AnimationGoing = false;
        }

        private double CalculateFluentAnimationSpeed(double i, double wantedHeight)
        {
            int recursor = this.Height;
            if (i - wantedHeight < recursor / 4)
            {
                return 1.2;
            }
            else if (i - wantedHeight < recursor / 3)
            {
                return 0.8;
            }
            else if (i - wantedHeight < recursor / 2)
            {
                return 0.5;
            }

            return 0.9;
        }
    }
}
