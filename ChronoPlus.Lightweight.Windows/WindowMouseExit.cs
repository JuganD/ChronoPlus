using System.Windows.Forms;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x86 && this.Visible && !this.AnimationGoing) //NativeConstants.WM_NCACTIVATE
            { 
                if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))// click outside the form's window
                    CloseWindow();
            }
            base.WndProc(ref m);
        }
    }
}
