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
            this.informationPanel.Visible = true;
            this.progressSpinner.Visible = true;

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

        private void PresentChronoCheckModel(ChronoCheckInformationModel model)
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

            labels[0].Text = "Email: " + model.Email;
            labels[1].Text = "Coins: " + model.Coins.Balance.ToString();
            labels[2].Text = "Last Spin: " + model.Coins.LastSpin.ToLocalTime().ToString(CultureInfo.CurrentCulture);

            labels = null;
            this.informationPanel.Visible = true;
        }

        private async Task<ChronoCheckInformationModel> GetChronoCheckModel(string jwt)
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
        private void DisposeComponents()
        {
            this.progressSpinner.Visible = false;
            this.progressSpinner.Dispose();
            this.informationPanel.Dispose();
        }

        private async Task ProgressSpinnerSpin()
        {
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
