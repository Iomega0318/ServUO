using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.RandomEvent
{
    class GameScoreboard : Gump
    {
        public GameScoreboard(int team1, int team2) : base(125, 100)
        {
            Dragable = false;
            Closable = false;

            int x = 50;
            int y = 20;

            AddImage(0, 0, 40012, 1176);

            AddLabel(x + 115, y, 1152, "Team British");

            if (team1 > team2)
                AddLabel(x + 250, y, 62, "Score = " + team1.ToString());
            else if(team1 < team2)
                AddLabel(x + 250, y, 37, "Score = " + team1.ToString());
            else if (team1 == team2)
                AddLabel(x + 250, y, 53, "Score = " + team1.ToString());

            AddLabel(x + 25, y + 25, 53, "Player");
            AddLabel(x + 290, y + 25, 53, "Points");
            AddLabel(x + 345, y + 25, 53, "Kills");
            AddLabel(x + 390, y + 25, 53, "Deaths");

            if (GameMain.TeamOne.Count > 0)
            {
                if (GameMain.TeamOne.Count > 0)
                    AddLabel(x + 15, y + 45, 1152, $"{GameMain.TeamOne[0].Name}");
                if (GameMain.TeamOne.Count > 1)
                    AddLabel(x + 15, y + 60, 1152, $"{GameMain.TeamOne[1].Name}");
                if (GameMain.TeamOne.Count > 2)
                    AddLabel(x + 15, y + 75, 1152, $"{GameMain.TeamOne[2].Name}");
                if (GameMain.TeamOne.Count > 3)
                    AddLabel(x + 15, y + 90, 1152, $"{GameMain.TeamOne[3].Name}");
                if (GameMain.TeamOne.Count > 4)
                    AddLabel(x + 15, y + 105, 1152, $"{GameMain.TeamOne[4].Name}");
                if (GameMain.TeamOne.Count > 5)
                    AddLabel(x + 15, y + 120, 1152, $"{GameMain.TeamOne[5].Name}");
                if (GameMain.TeamOne.Count > 6)
                    AddLabel(x + 15, y + 135, 1152, $"{GameMain.TeamOne[6].Name}");
                if (GameMain.TeamOne.Count > 7)
                    AddLabel(x + 15, y + 150, 1152, $"{GameMain.TeamOne[7].Name}");
                if (GameMain.TeamOne.Count > 8)
                    AddLabel(x + 15, y + 165, 1152, $"{GameMain.TeamOne[8].Name}");
                if (GameMain.TeamOne.Count > 9)
                    AddLabel(x + 15, y + 180, 1152, $"{GameMain.TeamOne[9].Name}");

                if (GameMain.TeamOne.Count > 0)
                {
                    GamePlayer gp = GameMain.TeamOne[0].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 45, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 45, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 45, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 1)
                {
                    GamePlayer gp = GameMain.TeamOne[1].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 60, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 60, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 60, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 2)
                {
                    GamePlayer gp = GameMain.TeamOne[2].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 75, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 75, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 75, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 3)
                {
                    GamePlayer gp = GameMain.TeamOne[3].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 90, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 90, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 90, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 4)
                {
                    GamePlayer gp = GameMain.TeamOne[4].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 105, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 105, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 105, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 5)
                {
                    GamePlayer gp = GameMain.TeamOne[5].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 120, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 120, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 120, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 6)
                {
                    GamePlayer gp = GameMain.TeamOne[6].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 135, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 135, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 135, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 7)
                {
                    GamePlayer gp = GameMain.TeamOne[7].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 150, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 150, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 150, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 8)
                {
                    GamePlayer gp = GameMain.TeamOne[8].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;

                    AddLabel(x + 300, y + 165, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 165, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 165, 1152, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamOne.Count > 9)
                {
                    GamePlayer gp = GameMain.TeamOne[9].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 180, 1152, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 180, 1152, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 180, 1152, $"{gp.TotalDeaths}");
                }
            }

            AddLabel(x + 115, 220, 1174, "Team Blackthorn");

            if (team1 < team2)
                AddLabel(x + 250, 220, 62, "Score = " + team2.ToString());
            else if (team1 > team2)
                AddLabel(x + 250, 220, 37, "Score = " + team2.ToString());
            else if (team1 == team2)
                AddLabel(x + 250, 220, 53, "Score = " + team2.ToString());

            AddLabel(x + 25, y + 225, 53, "Player");
            AddLabel(x + 290, y + 225, 53, "Points");
            AddLabel(x + 345, y + 225, 53, "Kills");
            AddLabel(x + 390, y + 225, 53, "Deaths");

            if (GameMain.TeamTwo.Count > 0)
            {
                if (GameMain.TeamTwo.Count > 0)
                    AddLabel(x + 15, y + 245, 1174, $"{GameMain.TeamTwo[0].Name}");
                if (GameMain.TeamTwo.Count > 1)
                    AddLabel(x + 15, y + 260, 1174, $"{GameMain.TeamTwo[1].Name}");
                if (GameMain.TeamTwo.Count > 2)
                    AddLabel(x + 15, y + 275, 1174, $"{GameMain.TeamTwo[2].Name}");
                if (GameMain.TeamTwo.Count > 3)
                    AddLabel(x + 15, y + 290, 1174, $"{GameMain.TeamTwo[3].Name}");
                if (GameMain.TeamTwo.Count > 4)
                    AddLabel(x + 15, y + 305, 1174, $"{GameMain.TeamTwo[4].Name}");
                if (GameMain.TeamTwo.Count > 5)
                    AddLabel(x + 15, y + 320, 1174, $"{GameMain.TeamTwo[5].Name}");
                if (GameMain.TeamTwo.Count > 6)
                    AddLabel(x + 15, y + 335, 1174, $"{GameMain.TeamTwo[6].Name}");
                if (GameMain.TeamTwo.Count > 7)
                    AddLabel(x + 15, y + 350, 1174, $"{GameMain.TeamTwo[7].Name}");
                if (GameMain.TeamTwo.Count > 8)
                    AddLabel(x + 15, y + 365, 1174, $"{GameMain.TeamTwo[8].Name}");
                if (GameMain.TeamTwo.Count > 9)
                    AddLabel(x + 15, y + 380, 1174, $"{GameMain.TeamTwo[9].Name}");

                if (GameMain.TeamTwo.Count > 0)
                {
                    GamePlayer gp = GameMain.TeamTwo[0].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 245, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 245, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 245, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 1)
                {
                    GamePlayer gp = GameMain.TeamTwo[1].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 260, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 260, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 260, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 2)
                {
                    GamePlayer gp = GameMain.TeamTwo[2].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 275, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 275, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 275, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 3)
                {
                    GamePlayer gp = GameMain.TeamTwo[3].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 290, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 290, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 290, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 4)
                {
                    GamePlayer gp = GameMain.TeamTwo[4].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 305, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 305, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 305, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 5)
                {
                    GamePlayer gp = GameMain.TeamTwo[5].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 320, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 320, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 320, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 6)
                {
                    GamePlayer gp = GameMain.TeamTwo[6].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 335, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 335, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 335, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 7)
                {
                    GamePlayer gp = GameMain.TeamTwo[7].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 350, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 350, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 350, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 8)
                {
                    GamePlayer gp = GameMain.TeamTwo[8].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 365, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 365, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 365, 1174, $"{gp.TotalDeaths}");
                }

                if (GameMain.TeamTwo.Count > 9)
                {
                    GamePlayer gp = GameMain.TeamTwo[9].Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;
                    AddLabel(x + 300, y + 380, 1174, $"{gp.TotalPoints}");
                    AddLabel(x + 350, y + 380, 1174, $"{gp.TotalKills}");
                    AddLabel(x + 400, y + 380, 1174, $"{gp.TotalDeaths}");
                }
            }

            AddButton(x + 475, y, 11410, 11412, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile player = sender.Mobile as PlayerMobile;

            switch (info.ButtonID)
            {
                case 0:
                    break;
                case 1:
                    {
                        GameMain.ReturnPlayer(player);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
