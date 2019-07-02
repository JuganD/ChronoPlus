using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChronoPlus.Controller.Models;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Interfaces;
using Label = System.Reflection.Emit.Label;

namespace ChronoPlus.Lightweight.Windows
{
    public partial class Window
    {
        // Its void for a reason, okay?
        private async void InitializeChronoComponents(string jwt = null)
        {
            if (string.IsNullOrEmpty(jwt))
            {
                FileManager fm = new FileManager();
                jwt = fm.ReadJwt();
            }

            if (jwt != null)
            {
                this.autoSpinToggle.Enabled = true;
                var model = await GetChronoCheckModel(jwt);
                PresentChronoCheckModel(model);
            }
            else
            {
                this.autoSpinToggle.Enabled = false;
                // TODO: get the jwt from the user
                FileManager fm = new FileManager();
                fm.SaveJWT(
                    "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Im5pc2h0b2RydWdvQGdtYWlsLmNvbSIsImlkIjoianVnYW5kIiwidWlkIjoiNWIyNTU1MDVlOGQ5MWIwMDExNzY5ZDg4IiwiaWF0IjoxNTU3MTI1NjcyLCJleHAiOjE1NjIzMDk2NzIsImF1ZCI6Imh0dHBzOi8vd3d3LmNocm9uby5nZyIsImlzcyI6Imh0dHBzOi8vYXBpLmNocm9uby5nZyIsImp0aSI6ImVmNjE0NzczYTVlMjRhY2VhYmE3ZTFmNmQxNDlmNzVlIn0.8O2PlgZLsID0WTpCQg_76kwWqC-uxo4trz_2s_Pa2Io");
                InitializeChronoComponents();
            }
        }

        public void PresentChronoCheckModel(ChronoCheckInformationModel model)
        {
            MetroLabel[] labels = new MetroLabel[3];

            Point location = new Point(0, 0);
            int incremetor = this.informationPanel.Height / labels.Length;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new MetroLabel
                {
                    Theme = MetroThemeStyle.Dark,
                    LabelMode = MetroLabelMode.Selectable,
                    AutoSize = true,
                    FontSize = MetroLabelSize.Tall,
                    Location = location
                };
                this.informationPanel.Controls.Add(labels[i]);

                location.Y += incremetor + labels[i].Height;
            }


            ChangeLabelText(labels[0], "Email: " + model.Email);
            ChangeLabelText(labels[1], "Coins: " + model.Coins.Balance.ToString());
            ChangeLabelText(labels[2], "Last Spin: " + model.Coins.LastSpin.ToLocalTime()
                                 .ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));

            labels = null;
            this.informationPanel.Visible = true;
        }

        public void PresentChronoSpinModel(ChronoCoinInformationModel model)
        {
            MetroLabel[] labels = new MetroLabel[2];

            Point location = new Point(0, 0);
            int incremetor = this.informationPanel.Height / labels.Length;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new MetroLabel
                {
                    Theme = MetroThemeStyle.Dark,
                    LabelMode = MetroLabelMode.Selectable,
                    AutoSize = true,
                    FontSize = MetroLabelSize.Tall,
                    Location = location
                };
                this.informationPanel.Controls.Add(labels[i]);
                this.DoubleBuffered = true;
                this.informationPanel.Refresh();
                location.Y += incremetor + labels[i].Height;
            }

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
    }
}
