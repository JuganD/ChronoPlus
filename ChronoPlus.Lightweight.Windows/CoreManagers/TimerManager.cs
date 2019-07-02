using System;
using System.Threading;
using System.Threading.Tasks;
using ChronoPlus.Controller.Models;
using System.Timers;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class TimerManager  // implement Idisposable
    {
        private System.Windows.Forms.Timer timer;
        public TimerManager()
        {
            timer = new System.Windows.Forms.Timer();

            timer.Interval = GetRemainingTime();
            timer.Tick += CallBack;
            timer.Start();
        }
        private async void CallBack(object sender, EventArgs e)
        {
            timer.Stop();

            if (Window.currentWindow != null)
            {
                Window.Kill();
            }

            FileManager fm = new FileManager();
            if (fm.IsJwtPresent)
            {
                string jwt = fm.ReadJwt();
                using (Controller controller = new Controller(jwt))
                {
                    ChronoCoinInformationModel spinInfo = controller.SpinCoin();
                    // FOR TESTING PURPOSE
                    //new ChronoCoinInformationModel()
                    //{
                    //    Chest = new ChronoCoinChestInformationModel()
                    //    {
                    //        RewardBonus = 5,
                    //        RewardValue = 10
                    //    },
                    //    Quest = new ChronoCoinQuestInformationModel()
                    //    {
                    //        RewardValue = 7,
                    //        RewardBonus = 3
                    //    }
                    //};
                    if (spinInfo != null)
                    {
                        if (spinInfo.Quest.RewardBonus + spinInfo.Quest.RewardValue != 0)
                        {
                            this.timer.Interval = GetRemainingTime();
                            timer.Start();

                            Window wind = new Window(true);
                            await wind?.DisplayPopUpAnimation();
                            await wind?.GetChronoSpinModel(jwt);
                            wind?.PresentChronoSpinModel(spinInfo);
                        }
                    }
                }
            }
        }

        public static int GetRemainingTime()
        {
            DateTime now = DateTime.UtcNow;
            DateTime fourOClock = DateTime.Today.AddHours(16).AddMinutes(1);

            if (now > fourOClock)
            {
                fourOClock = fourOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((fourOClock - now).TotalMilliseconds);

            return msUntilFour;
        }
    }
}
