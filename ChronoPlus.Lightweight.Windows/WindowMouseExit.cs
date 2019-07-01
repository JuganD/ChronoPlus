using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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
