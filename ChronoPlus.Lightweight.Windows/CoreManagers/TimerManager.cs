using System;
using ChronoPlus.Controller.Models;

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
            if (ConfigManager.GetConfigBool("autoSpinToggle") != false)
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
                                // TODO: check for new offers
                            }
                        }
                        if (controller.ResponseResult == Result.InvalidToken)
                        {
                            if (IconManager.icon != null)
                                IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! Invalid/expired JWT token!", System.Windows.Forms.ToolTipIcon.Error);
                        } else if (controller.ResponseResult == Result.Unknown)
                        {
                            if (IconManager.icon != null)
                                IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! Chrono spin not successful, check your internet connection!", System.Windows.Forms.ToolTipIcon.Error);
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
            DateTime fiveOClock = DateTime.Today.AddHours(17).AddMinutes(1);

            if (now > fiveOClock)
            {
                fiveOClock = fiveOClock.AddDays(1.0);
            }
            int msUntilFour = (int)((fiveOClock - now).TotalMilliseconds);

            return msUntilFour;
        }
    }
}
