using Server.Mobiles;
using System.Collections.Generic;

namespace Server.RandomEvent
{
    public class GameHistory
    {
        public PlayerMobile Player { get; set; }

        public int GameTokens { get; set; }

        public int TeamBritish { get; set; }
        public int TeamBlackthorn { get; set; }

        //Overall Totals
        public int TotalWins { get; set; }
        public int TotalLoses { get; set; }
        public int TotalPoints { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalGold { get; set; }

        public List<GameRecord> Records { get; set; }

        public GameHistory()
        {
            if (Records == null)
                Records = new List<GameRecord>();
            else
                Records.Clear();

            if (Records.Count == 0)
            {
                Records.Add(new GameRecord(0)); //Default : No Game Placeholder 
                Records.Add(new GameRecord((int)GameMain.GameTypes.Capture_The_Flag));
                Records.Add(new GameRecord((int)GameMain.GameTypes.Team_Death_Match));
                Records.Add(new GameRecord((int)GameMain.GameTypes.Team_Elimination));
                Records.Add(new GameRecord((int)GameMain.GameTypes.Slime_Death_Match));
                Records.Add(new GameRecord((int)GameMain.GameTypes.Super_Death_Match));
            }
        }
    }
}
