using System;
using System.Threading;
using System.Threading.Tasks;
using ChronoPlus.Controller.Models;
using System.Timers;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class TimerManager
    {
        private System.Windows.Forms.Timer timer;
        public TimerManager()
        {
            timer = new System.Windows.Forms.Timer();

            timer.Interval = GetRemainingTime();
            timer.Tick += CallBack;
            timer.Start();
            CallBack(null, null);
        }
        private void CallBack(object sender, EventArgs e)
        {
            timer.Stop();
            if (ConfigManager.GetConfigValue("autoSpinToggle") != false)
            {
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
                            int questCoins = spinInfo.Quest.RewardBonus + spinInfo.Quest.RewardValue;
                            int chestCoins = spinInfo.Chest.RewardBonus + spinInfo.Chest.RewardValue;
                            if (questCoins > 0)
                            {
                                Window.InsertedLabels.Add("[2]Last coin spin");
                                Window.InsertedLabels.Add("    From daily spin: " + questCoins);
                                if (chestCoins > 0)
                                {
                                    Window.InsertedLabels.Add("    From chest reward: " + chestCoins);
                                }
                                // TODO: add option to raise information in window
                                //Window wind = new Window(true);
                                //await wind?.DisplayPopUpAnimation();
                                //await wind?.GetChronoSpinModel(jwt);
                                //wind?.PresentChronoSpinModel(spinInfo);
                            }
                        }
                    }
                }
            }
            this.timer.Interval = GetRemainingTime();
            timer.Start();
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
