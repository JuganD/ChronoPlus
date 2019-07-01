using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private bool DisplayForm = false;
        private bool AllowClose = false;
        private Rectangle screenBounds;
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this.AllowClose)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                this.icon.Dispose();
            }
        }
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(this.DisplayForm ? value : this.DisplayForm);
        }

        private void ShowWindow()
        {
            this.DisplayForm = true;
            this.Visible = true;
        }
        private void HideWindow()
        {
            this.DisplayForm = false;
            this.Visible = false;
        }
        // Performs pop-up animation of the form
        private async Task DisplayAnimation(double speed = 30)
        {
            Point formPoint = new Point(screenBounds.Width - this.Width, screenBounds.Height);
            this.Location = formPoint;
            ShowWindow();
            int wantedHeight = screenBounds.Height - this.Height;

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
