﻿using System;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using ChronoPlus.Controller.Models;

namespace ChronoPlus.Lightweight.Windows.CoreManagers
{
    public class VoteManager
    {
        private static System.Windows.Forms.Timer timer;
        private static DateTime TimerStartTime;
        public VoteManager(bool startTimer = true)
        {
            if (startTimer)
            {
                timer = new System.Windows.Forms.Timer();

                timer.Interval = GetRemainingTime();
                timer.Tick += CallBack;
                TimerStartTime = DateTime.UtcNow;
                timer.Start();
            }

            CallBack(null, null);
        }
        private void CallBack(object sender, EventArgs e)
        {
            if (timer != null)
                timer.Stop();

            bool supressTimer = false; // in case of error, we can pick different time
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
                    try
                    {
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
                                }
                            }

                            CheckOffersAndPromptNotification(controller);

                            if (controller.ResponseResult == Result.InvalidToken)
                            {
                                if (IconManager.icon != null)
                                    IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! Invalid/expired JWT token!", System.Windows.Forms.ToolTipIcon.Error);
                            }
                            else if (controller.ResponseResult == Result.Unknown)
                            {
                                supressTimer = true;
                                if (IconManager.icon != null)
                                    IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! Chrono spin not successful, check your internet connection!", System.Windows.Forms.ToolTipIcon.Error);
                            }
                        }
                    }
                    catch (HttpRequestException)
                    {
                        supressTimer = true;
                        if (IconManager.icon != null)
                            IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! Chrono+ request exception! Possible cause: invalid SSL or other network-related error!", System.Windows.Forms.ToolTipIcon.Error);
                    }
                    catch
                    {
                        supressTimer = true;
                        if (IconManager.icon != null)
                            IconManager.icon.ShowBalloonTip(3000, "Chrono+", "Error! An error occured while Chrono+ was voting! Voting unsuccessful.", System.Windows.Forms.ToolTipIcon.Error);
                    }
                }
            }
            if (timer != null)
            {
                if (!supressTimer)
                {
                    timer.Interval = GetRemainingTime();
                    TimerStartTime = DateTime.UtcNow;
                    timer.Start();
                }
                else
                {
                    // An error occured and we set shorter timespan for the timer
                    // Set timer after an hour
                    // User can always turn it off by switching off autospin
                    timer.Interval = 3600000;
                    TimerStartTime = DateTime.UtcNow;
                    timer.Start();
                }
            }
        }
        public static long GetVoteTimeLeftTicks()
        {
            return (TimerStartTime.AddMilliseconds(timer.Interval) - DateTime.UtcNow).Ticks;
        }
        public int GetRemainingTime()
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

        // Sends check offers request, finds those offers which are released after the 
        // last check date and prompts notification if that is the case
        private void CheckOffersAndPromptNotification(Controller controller)
        {
            if (!ConfigManager.Config.ContainsKey("offersLastCheck"))
            {
                ConfigManager.Config.Add("offersLastCheck", DateTime.MinValue.ToString());
            }

            string lastCheckTimeString = ConfigManager.Config["offersLastCheck"];
            DateTime lastCheckTime = DateTime.Parse(lastCheckTimeString); // this is UTC

            bool lastCheckIsNotToday = (DateTime.UtcNow.Date - lastCheckTime.Date) >= TimeSpan.FromDays(1);
            if (lastCheckIsNotToday)
            {
                var offersModel = controller.CheckOffers();
                var newOffers = offersModel?.Offers
                    .Where(x => x.Active == true
                             && x.SoldOut == false
                             && x.CreatedOn > lastCheckTime);

                if (newOffers != null && newOffers.Any())
                {
                    Task.Run(async () =>
                    {
                        await Task.Delay(8000);
                        if (IconManager.icon != null)
                        {
                            string newOffersMessage = "New offers available!";

                            // Write the name of every offer if they are lower than 5
                            // (we don't want to write 100 offers for example)
                            if (newOffers.Count() <= 5)
                            {
                                newOffersMessage += " (" + string.Join(", ", newOffers.Select(x => x.Name)) + ")";
                            }

                            IconManager.BalloonTipClickedAction = delegate
                            {
                                System.Diagnostics.Process.Start("https://www.chrono.gg/shop");
                            };
                            IconManager.icon.ShowBalloonTip(5000, "Chrono+",
                                newOffersMessage,
                                System.Windows.Forms.ToolTipIcon.Info);

                            ConfigManager.Config["offersLastCheck"] = DateTime.UtcNow.ToString();
                            new ConfigManager().SaveConfig();
                        }
                    });
                }
            }
        }
    }
}
