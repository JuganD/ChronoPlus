using System;
using System.Threading.Tasks;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        private bool jwtButtonAnimated = false;
        private int jwtButtonDefaultValue = 0;
        private string jwtLastValue = null;
        private void JwtTextBox_TextChanged(object sender, EventArgs e)
        {
            if (jwtButtonDefaultValue == 0)
            {
                jwtButtonDefaultValue = this.jwtChangeButton.Width;
            }

            jwtButtonAnimated = false;
            JwtButtonAnimation();
        }
        private async void JwtButtonAnimation()
        {
            try
            {
                int buttonGoalWidth;
                if (!jwtButtonAnimated)
                {
                    buttonGoalWidth = (int)(jwtButtonDefaultValue * 0.60);
                    for (int i = this.jwtChangeButton.Width; i > buttonGoalWidth; i -= 2)
                    {
                        this.jwtChangeButton.Width = i;
                        await Task.Delay(10);
                    }
                }
                else
                {
                    buttonGoalWidth = jwtButtonDefaultValue;
                    for (int i = this.jwtChangeButton.Width; i < buttonGoalWidth; i += 2)
                    {
                        this.jwtChangeButton.Width = i;
                        await Task.Delay(10);
                    }
                }

                jwtButtonAnimated = !jwtButtonAnimated;
            }
            catch
            {
                if (jwtButtonAnimated)
                {
                    this.jwtChangeButton.Width = jwtButtonDefaultValue;
                    jwtButtonAnimated = false;
                }
            }
        }


        private void JwtButtonExitEvent(object sender, EventArgs e)
        {
            jwtButtonAnimated = true;
            JwtButtonAnimation();
            this.jwtTextBox.Text = jwtLastValue;
        }
        
        private void JwtChangeButton_Click(object sender, EventArgs e)
        {
            ApplyJwt(this.jwtTextBox.Text);
        }
    }
}
