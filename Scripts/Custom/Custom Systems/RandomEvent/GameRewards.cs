using Server.Items;

namespace Server.RandomEvent
{
    public static class GameRewards
    {
        public static void GiveReward(GamePlayer tracker)
        {
            int reward = CalculateReward(tracker);

            tracker.PM.Backpack.AddItem(new Gold(reward));

            tracker.PM.SendMessage(tracker.PM.Name + $", you have been rewarded {reward} gold coins!");

            tracker.PM.SendMessage(tracker.PM.Name + $", you have been rewarded Game Tokens - visit the Keeper of Events");

            tracker.PM.PlaySound(0x2E2);
        }

        private static int CalculateReward(GamePlayer tracker)
        {
            int reward = 100;

            if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
            {
                reward = tracker.TotalPoints + ((tracker.TotalPoints / 100) * tracker.TotalKills);

                reward = reward - ((tracker.TotalPoints / 100) * tracker.TotalDeaths);
            }
            else
            {
                reward = tracker.TotalPoints + (100 * tracker.TotalKills);

                reward = reward - (50 * tracker.TotalDeaths);
            }

            if (tracker.GameWon)
                reward = reward * 2;

            if (reward > 60000)
                reward = 60000;

            if (reward > 100)
                return reward;
            else
                return 100;
        }
    }
}
