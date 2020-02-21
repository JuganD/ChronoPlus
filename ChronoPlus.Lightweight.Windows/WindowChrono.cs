using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using ChronoPlus.Controller.Models;
using ChronoPlus.Lightweight.Windows.CoreManagers;
using MetroFramework;
using MetroFramework.Controls;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        public static List<string> InsertedLabels = new List<string>();
        // Its void for a reason, okay?
        private async void ApplyJwt(string jwt = null)
        {
            if (string.IsNullOrEmpty(jwt))
            {
                FileManager fm = new FileManager();
                jwt = fm.ReadJwt();

                if (jwt != null)
                {
                    this.autoSpinToggle.Enabled = true;
                    this.jwtTextBox.Text = jwt; // for initial textbox fill if jwt is presented
                    this.jwtLastValue = jwt;
                    var model = await GetChronoCheckModel(jwt);
                    PresentChronoCheckModel(model);
                }
            }
            else
            {
                this.autoSpinToggle.Enabled = true;
                FileManager fm = new FileManager();
                fm.SaveJWT(jwt);
                Kill(); // to trigger all window startup events
                Program.StartNewWindow();
            }
        }

        public void PresentChronoCheckModel(ChronoCheckInformationModel model)
        {
            List<MetroLabel> labels = (List<MetroLabel>)InsertLabelsToPanel(3, true);
            try
            {
                ChangeLabelText(labels[0], "Email: " + model.Email);
                ChangeLabelText(labels[1], "Coins: " + model.Coins.Balance.ToString());
                ChangeLabelText(labels[2], "Last Spin: " + model.Coins.LastSpin.ToLocalTime()
                                     .ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            }
            catch (NullReferenceException)
            {
                ChangeLabelText(labels[0], "Invalid JWT token or the server refused the request.");
            }


            labels = null;
            this.informationPanel.Visible = true;
        }

        public void PresentChronoSpinModel(ChronoCoinInformationModel model)
        {
            List<MetroLabel> labels = (List<MetroLabel>)InsertLabelsToPanel(2);

            ChangeLabelText(labels[0], "Quest coins: " + (model.Quest.RewardValue + model.Quest.RewardBonus));
            ChangeLabelText(labels[1], "Chest coins: " + (model.Chest.RewardValue + model.Chest.RewardBonus));

            labels = null;
            this.informationPanel.Visible = true;
        }
        private void ChangeLabelText(MetroLabel label, string text)
        {
            if (label != null && !label.IsDisposed && !label.Disposing)
            {
                try
                {
                    label.Text = text;
                }
                catch { }
            }
        }
        public ICollection<MetroLabel> InsertLabelsToPanel(int count, bool insertAdditional = false)
        {
            List<MetroLabel> labelsToAdd = new List<MetroLabel>();
            for (int i = 0; i < count; i++)
            {
                labelsToAdd.Add(new MetroLabel());
            }

            if (insertAdditional)
            {
                foreach (var label in InsertedLabels)
                {
                    labelsToAdd.Add(new MetroLabel()
                    {
                        Text = label
                    });
                }
            }

            Point location = new Point(0, 0);
            int incrementor = this.informationPanel.Height / labelsToAdd.Count;
            int subCounter = 0;
            for (int i = 0; i < labelsToAdd.Count; i++)
            {
                labelsToAdd[i].Theme = MetroThemeStyle.Dark;
                labelsToAdd[i].LabelMode = MetroLabelMode.Selectable;
                labelsToAdd[i].AutoSize = true;
                labelsToAdd[i].FontSize = MetroLabelSize.Tall;
                labelsToAdd[i].Location = location;

                this.informationPanel.Controls.Add(labelsToAdd[i]);

                try
                {
                    if (labelsToAdd[i].Text != null &&
                    labelsToAdd[i].Text.Length > 3 &&
                    labelsToAdd[i].Text.Substring(0, 1) == "[" &&
                    labelsToAdd[i].Text.Substring(2, 1) == "]")
                    {
                        subCounter = int.Parse(labelsToAdd[i].Text.Substring(1, 1)) + 1;
                        labelsToAdd[i].Text = labelsToAdd[i].Text.Remove(0, 3);
                    }
                }
                catch { }

                if (subCounter > 0)
                {
                    location.Y += labelsToAdd[i].Height;
                    subCounter--;
                }
                else
                    location.Y += incrementor;
            }
            return labelsToAdd;
        }
        public async Task<ChronoCheckInformationModel> GetChronoCheckModel(string jwt)
        {
            using (Controller controller = new Controller(jwt))
            {
                Task<ChronoCheckInformationModel> userInfo = Task.Run(() => controller.CheckUser());

                while (!userInfo.IsCompleted)
                {
                    await ProgressSpinnerSpin();
                }
                ChronoCheckInformationModel model = await userInfo;
                ProgressSpinnerComplete();
                userInfo.Dispose();

                return model;
            }
        }
        public async Task<ChronoCoinInformationModel> GetChronoSpinModel(string jwt)
        {
            using (Controller controller = new Controller(jwt))
            {
                Task<ChronoCoinInformationModel> userInfo = Task.Run(() => controller.SpinCoin());

                while (!userInfo.IsCompleted)
                {
                    await ProgressSpinnerSpin();
                }
                
                ChronoCoinInformationModel model = await userInfo;
                ProgressSpinnerComplete();
                userInfo.Dispose();

                return model;
            }
        }
        private void DisposeComponents()
        {
            this.progressSpinner.Visible = false;
            this.progressSpinner.Dispose();
            this.informationPanel.Dispose();
        }

        private async Task ProgressSpinnerSpin()
        {
            if (this.informationPanel.Visible == false || this.progressSpinner.Visible == false)
            {
                this.informationPanel.Visible = true;
                this.progressSpinner.Visible = true;
            }

            if (this.progressSpinner.Value == 0)
            {
                for (int i = 0; i <= 100; i += 1)
                {
                    this.progressSpinner.Value = i;
                    await Task.Delay(10);
                }

            }
            else if (this.progressSpinner.Value == 100)
            {
                float speed = this.progressSpinner.Speed;
                this.progressSpinner.Speed = 0.01f;
                for (int i = 100; i >= 0; i -= 2)
                {
                    this.progressSpinner.Value = i;
                    await Task.Delay(8);
                }

                this.progressSpinner.Speed = speed;
            }
            else
            {
                this.progressSpinner.Value = 0;
                await ProgressSpinnerSpin();
            }
        }

        private async void ProgressSpinnerComplete()
        {
            this.progressSpinner.Value = 100;
            await Task.Delay(50);
            this.progressSpinner.Hide();
            this.progressSpinner.Value = 0;
        }
        private void SetNextRollTime()
        {
            TimeSpan t = TimeSpan.FromMilliseconds(VoteManager.GetRemainingTime());
            string time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);

            this.nextRollTime.Text = time;
        }
    }
}
