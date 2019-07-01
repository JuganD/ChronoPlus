using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private readonly NotifyIcon icon = new NotifyIcon();

        private void NotifyIcon_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible)
                    HideWindow();
                else
                    DisplayAnimation();
            }
        }

        private void NotifyIcon_CloseClicked(object sender, EventArgs e)
        {
            this.AllowClose = true;
            this.DisplayForm = true;
            this.Location = new Point(this.screenBounds.Width + 20, this.screenBounds.Height + 20);
            this.Visible = !this.Visible;
            this.Close();
        }
    }
}
