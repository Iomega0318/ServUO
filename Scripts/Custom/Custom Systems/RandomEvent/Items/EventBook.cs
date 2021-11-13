using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.RandomEvent
{
    public class EventBook : RedBook
    {
        public static int TotalGamesPlayed { get; set; }

        public static List<GameHistory> BaseGameHistory { get; set; }
        public static List<GameHistory> CTFGameHistory { get; set; }
        public static List<GameHistory> TDMGameHistory { get; set; }
        public static List<GameHistory> TEGameHistory { get; set; }
        public static List<GameHistory> TSGameHistory { get; set; }
        public static List<GameHistory> SDMGameHistory { get; set; }

        public static readonly BookContent Content = new BookContent // removed static
        (
            "Records - Top Ten", "Keeper of Events",

            //First Page
            new BookPageInfo(
                "Top Ten Player Log",
                "",
                "All deeds are kept",
                "in the book, if this",
                "book were stolen or",
                "worse, destroyed!",
                "",
                "It would be a great",
                "loss for those that",
                "worked hard to get",
                "their deeds recorded!"),

            //Capture the Flag
            new BookPageInfo(
                "Capture the Flag",
                $"1.{GetCTFPlayer(0)}",
                $"2.{GetCTFPlayer(1)}",
                $"3.{GetCTFPlayer(2)}",
                $"4.{GetCTFPlayer(3)}",
                $"5.{GetCTFPlayer(4)}",
                $"6.{GetCTFPlayer(5)}",
                $"7.{GetCTFPlayer(6)}",
                $"8.{GetCTFPlayer(7)}",
                $"9.{GetCTFPlayer(8)}",
                $"10.{GetCTFPlayer(9)}"),

            //Team Death Match
            new BookPageInfo(
                "Team Death Match",
                $"1.{GetTDMPlayer(0)}",
                $"2.{GetTDMPlayer(1)}",
                $"3.{GetTDMPlayer(2)}",
                $"4.{GetTDMPlayer(3)}",
                $"5.{GetTDMPlayer(4)}",
                $"6.{GetTDMPlayer(5)}",
                $"7.{GetTDMPlayer(6)}",
                $"8.{GetTDMPlayer(7)}",
                $"9.{GetTDMPlayer(8)}",
                $"10.{GetTDMPlayer(9)}"),

            //Team Elimination
            new BookPageInfo(
                "Team Elimination",
                $"1.{GetTEPlayer(0)}",
                $"2.{GetTEPlayer(1)}",
                $"3.{GetTEPlayer(2)}",
                $"4.{GetTEPlayer(3)}",
                $"5.{GetTEPlayer(4)}",
                $"6.{GetTEPlayer(5)}",
                $"7.{GetTEPlayer(6)}",
                $"8.{GetTEPlayer(7)}",
                $"9.{GetTEPlayer(8)}",
                $"10.{GetTEPlayer(9)}"),

            //Team Slime
            new BookPageInfo(
                "Team Slime",
                $"1.{GetTSPlayer(0)}",
                $"2.{GetTSPlayer(1)}",
                $"3.{GetTSPlayer(2)}",
                $"4.{GetTSPlayer(3)}",
                $"5.{GetTSPlayer(4)}",
                $"6.{GetTSPlayer(5)}",
                $"7.{GetTSPlayer(6)}",
                $"8.{GetTSPlayer(7)}",
                $"9.{GetTSPlayer(8)}",
                $"10.{GetTSPlayer(9)}"),

            //Super Death Match
            new BookPageInfo(
                "Super Death Match",
                $"1.{GetSDMPlayer(0)}",
                $"2.{GetSDMPlayer(1)}",
                $"3.{GetSDMPlayer(2)}",
                $"4.{GetSDMPlayer(3)}",
                $"5.{GetSDMPlayer(4)}",
                $"6.{GetSDMPlayer(5)}",
                $"7.{GetSDMPlayer(6)}",
                $"8.{GetSDMPlayer(7)}",
                $"9.{GetSDMPlayer(8)}",
                $"10.{GetSDMPlayer(9)}"),

            //Last Page
            new BookPageInfo(
                $"Games Hosted : {TotalGamesPlayed}",
                "",
                "Top Points Overall",
                $"{GetTopPoints()}",
                "",
                "Top Kills Overall",
                $"{GetTopKills()}",
                "",
                "Top Gold Overall",
                $"{GetTopGold()}",
                "")
        );

        public override bool Decays => false;

        [Constructable]
        public EventBook() : base()
        {
            Name = "Event Game Book";
            Author = "Keeper of Events";
            Title = "Event Game Log";

            Hue = 1153;

            LootType = LootType.Blessed;
            Movable = false;

            if (BaseGameHistory == null)
            {
                TotalGamesPlayed = 0;

                BaseGameHistory = new List<GameHistory>();
                CTFGameHistory = new List<GameHistory>();
                TDMGameHistory = new List<GameHistory>();
                TEGameHistory = new List<GameHistory>();
                TSGameHistory = new List<GameHistory>();
                SDMGameHistory = new List<GameHistory>();
            }
        }

        public EventBook(Serial serial) : base(serial)
        {
        }

        public override BookContent DefaultContent
        {
            get
            {
                return Content;
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            list.Add("Event Game Log");
        }

        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, "Event Game Book");
        }

        public static void UpdateGameHistory(GameHistory gameHistory)
        {
            bool HasRecord = false;
            GameHistory history = null;

            if (BaseGameHistory != null && BaseGameHistory.Count > 0)
            {
                foreach (GameHistory GH in BaseGameHistory)
                {
                    if (GH.Player == gameHistory.Player)
                    {
                        history = GH;
                        HasRecord = true;
                    }
                }
            }

            if (HasRecord)
            {
                history.GameTokens += gameHistory.GameTokens;

                history.TeamBritish += gameHistory.TeamBritish;
                history.TeamBlackthorn += gameHistory.TeamBlackthorn;

                //Overall Totals
                history.TotalWins += gameHistory.TotalWins;
                history.TotalLoses += gameHistory.TotalLoses;
                history.TotalPoints += gameHistory.TotalPoints;
                history.TotalKills += gameHistory.TotalKills;
                history.TotalDeaths += gameHistory.TotalDeaths;
                history.TotalGold += gameHistory.TotalGold;

                UpdateGameRecord(history, gameHistory, (int)GameMain.GameTypes.Capture_The_Flag);

                UpdateGameRecord(history, gameHistory, (int)GameMain.GameTypes.Team_Death_Match);

                UpdateGameRecord(history, gameHistory, (int)GameMain.GameTypes.Team_Elimination);

                UpdateGameRecord(history, gameHistory, (int)GameMain.GameTypes.Slime_Death_Match);

                UpdateGameRecord(history, gameHistory, (int)GameMain.GameTypes.Super_Death_Match);
            }
            else
            {
                if (BaseGameHistory == null)
                    BaseGameHistory = new List<GameHistory>();

                BaseGameHistory.Add(gameHistory);
            }
        }

        public static void UpdateGameRecord(GameHistory old_history, GameHistory new_history, int game)
        {
            old_history.Records[game].Wins = new_history.Records[game].Wins;
            old_history.Records[game].Loses = new_history.Records[game].Loses;
            old_history.Records[game].Points = new_history.Records[game].Points;
            old_history.Records[game].Kills = new_history.Records[game].Kills;
            old_history.Records[game].Deaths = new_history.Records[game].Deaths;
            old_history.Records[game].Gold = new_history.Records[game].Gold;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (BaseGameHistory != null && BaseGameHistory.Count > 10)
            {
                GetTopTenCTF();
                GetTopTenTDM();
                GetTopTenTE();
                GetTopTenTS();
                GetTopTenSDM();
            }
            else
            {
                PublicOverheadMessage(Network.MessageType.Regular, 53, true, "Wilson has made a mess of the book, check back in the future!");
            }

            base.OnDoubleClick(from);
        }

        public void GetTopTenCTF()
        {
            if (CTFGameHistory != null)
            {
                CTFGameHistory.Clear();
                CTFGameHistory.AddRange(BaseGameHistory);
                CTFGameHistory.Sort((x, y) => x.Records[(int)GameMain.GameTypes.Capture_The_Flag].Points.CompareTo(y.Records[(int)GameMain.GameTypes.Capture_The_Flag].Points));
            }
        }

        public static string GetCTFPlayer(int pos)
        {
            if (CTFGameHistory != null && CTFGameHistory.Count > 10)
            {
                return $"{CTFGameHistory[pos].Player.Name.Substring(0, 9)} - {CTFGameHistory[pos].Records[(int)GameMain.GameTypes.Capture_The_Flag].Points}";
            }
            else
            {
                return "Wilson - 199" + pos.ToString();
            }
        }

        public void GetTopTenTDM()
        {
            if (TDMGameHistory != null)
            {
                TDMGameHistory.Clear();
                TDMGameHistory.AddRange(BaseGameHistory);
                TDMGameHistory.Sort((x, y) => x.Records[(int)GameMain.GameTypes.Team_Death_Match].Points.CompareTo(y.Records[(int)GameMain.GameTypes.Team_Death_Match].Points));
            }
        }

        public static string GetTDMPlayer(int pos)
        {
            if (TDMGameHistory != null && TDMGameHistory.Count > 10)
            {
                return $"{TDMGameHistory[pos].Player.Name.Substring(0, 9)} - {TDMGameHistory[pos].Records[(int)GameMain.GameTypes.Team_Death_Match].Points}";
            }
            else
            {
                return "Wilson - 199" + pos.ToString();
            }
        }

        public void GetTopTenTE()
        {
            if (TEGameHistory != null)
            {
                TEGameHistory.Clear();
                TEGameHistory.AddRange(BaseGameHistory);
                TEGameHistory.Sort((x, y) => x.Records[(int)GameMain.GameTypes.Team_Elimination].Points.CompareTo(y.Records[(int)GameMain.GameTypes.Team_Elimination].Points));
            }
        }

        public static string GetTEPlayer(int pos)
        {
            if (TEGameHistory != null && TEGameHistory.Count > 10)
            {
                return $"{TEGameHistory[pos].Player.Name.Substring(0, 9)} - {TEGameHistory[pos].Records[(int)GameMain.GameTypes.Team_Elimination].Points}";
            }
            else
            {
                return "Wilson - 199" + pos.ToString();
            }
        }

        public void GetTopTenTS()
        {
            if (TSGameHistory != null)
            {
                TSGameHistory.Clear();
                TSGameHistory.AddRange(BaseGameHistory);
                TSGameHistory.Sort((x, y) => x.Records[(int)GameMain.GameTypes.Slime_Death_Match].Points.CompareTo(y.Records[(int)GameMain.GameTypes.Slime_Death_Match].Points));
            }
        }

        public static string GetTSPlayer(int pos)
        {
            if (TSGameHistory != null && TSGameHistory.Count > 10)
            {
                return $"{TSGameHistory[pos].Player.Name.Substring(0, 9)} - {TSGameHistory[pos].Records[(int)GameMain.GameTypes.Slime_Death_Match].Points}";
            }
            else
            {
                return "Wilson - 199" + pos.ToString();
            }
        }

        public void GetTopTenSDM()
        {
            if (SDMGameHistory != null)
            {
                SDMGameHistory.Clear();
                SDMGameHistory.AddRange(BaseGameHistory);
                SDMGameHistory.Sort((x, y) => x.Records[(int)GameMain.GameTypes.Super_Death_Match].Points.CompareTo(y.Records[(int)GameMain.GameTypes.Super_Death_Match].Points));
            }
        }

        public static string GetSDMPlayer(int pos)
        {
            if (SDMGameHistory != null && SDMGameHistory.Count > 10)
            {
                return $"{SDMGameHistory[pos].Player.Name.Substring(0, 9)} - {SDMGameHistory[pos].Records[(int)GameMain.GameTypes.Super_Death_Match].Points}";
            }
            else
            {
                return "Wilson - 199" + pos.ToString();
            }
        }

        private static string GetTopPoints()
        {
            if (BaseGameHistory != null && BaseGameHistory.Count > 10)
            {
                BaseGameHistory.Sort((x, y) => x.TotalPoints.CompareTo(y.TotalPoints));

                return BaseGameHistory[0].Player.Name.Substring(0, 9) + " - " + BaseGameHistory[0].TotalPoints;
            }
            else
            {
                return "Wilson - 1997";
            }
        }

        private static string GetTopKills()
        {
            if (BaseGameHistory != null && BaseGameHistory.Count > 10)
            {
                BaseGameHistory.Sort((x, y) => x.TotalKills.CompareTo(y.TotalKills));

                return BaseGameHistory[0].Player.Name.Substring(0, 9) + " - " + BaseGameHistory[0].TotalKills;
            }
            else
            {
                return "Wilson - 1997";
            }
        }

        private static string GetTopGold()
        {
            if (BaseGameHistory != null && BaseGameHistory.Count > 10)
            {
                BaseGameHistory.Sort((x, y) => x.TotalGold.CompareTo(y.TotalGold));

                return BaseGameHistory[0].Player.Name.Substring(0, 9) + " - " + BaseGameHistory[0].TotalGold;
            }
            else
            {
                return "Wilson - 1997";
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version

            writer.Write(TotalGamesPlayed);

            writer.Write(BaseGameHistory.Count);

            foreach (GameHistory history in BaseGameHistory)
            {
                writer.Write(history.Player as Mobile);

                writer.Write(history.GameTokens);
                writer.Write(history.TeamBritish);
                writer.Write(history.TeamBlackthorn);

                writer.Write(history.TotalWins);
                writer.Write(history.TotalLoses);
                writer.Write(history.TotalPoints);
                writer.Write(history.TotalKills);
                writer.Write(history.TotalDeaths);
                writer.Write(history.TotalGold);

                WriteRecords(writer, history, (int)GameMain.GameTypes.Capture_The_Flag);

                WriteRecords(writer, history, (int)GameMain.GameTypes.Team_Death_Match);

                WriteRecords(writer, history, (int)GameMain.GameTypes.Team_Elimination);

                WriteRecords(writer, history, (int)GameMain.GameTypes.Slime_Death_Match);

                WriteRecords(writer, history, (int)GameMain.GameTypes.Super_Death_Match);
            }
        }

        public void WriteRecords(GenericWriter writer, GameHistory history, int game)
        {
            writer.Write(history.Records[game].Wins);
            writer.Write(history.Records[game].Loses);
            writer.Write(history.Records[game].Points);
            writer.Write(history.Records[game].Kills);
            writer.Write(history.Records[game].Deaths);
            writer.Write(history.Records[game].Gold);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();

            TotalGamesPlayed = reader.ReadInt();

            int HistoryCount = reader.ReadInt();

            BaseGameHistory = new List<GameHistory>();
            CTFGameHistory = new List<GameHistory>();
            TDMGameHistory = new List<GameHistory>();
            TEGameHistory = new List<GameHistory>();
            TSGameHistory = new List<GameHistory>();
            SDMGameHistory = new List<GameHistory>();

            for (int i = 0; i < HistoryCount; i++)
            {
                GameHistory history = new GameHistory
                {
                    Player = reader.ReadMobile() as PlayerMobile,

                    GameTokens = reader.ReadInt(),
                    TeamBritish = reader.ReadInt(),
                    TeamBlackthorn = reader.ReadInt(),

                    TotalWins = reader.ReadInt(),
                    TotalLoses = reader.ReadInt(),
                    TotalPoints = reader.ReadInt(),
                    TotalKills = reader.ReadInt(),
                    TotalDeaths = reader.ReadInt(),
                    TotalGold = reader.ReadInt()
                };

                ReadRecords(reader, history, (int)GameMain.GameTypes.Capture_The_Flag);

                ReadRecords(reader, history, (int)GameMain.GameTypes.Team_Death_Match);

                ReadRecords(reader, history, (int)GameMain.GameTypes.Team_Elimination);

                ReadRecords(reader, history, (int)GameMain.GameTypes.Slime_Death_Match);

                ReadRecords(reader, history, (int)GameMain.GameTypes.Super_Death_Match);

                BaseGameHistory.Add(history);
            }
        }

        public void ReadRecords(GenericReader reader, GameHistory history, int game)
        {
            history.Records[game].Wins = reader.ReadInt(); 
            history.Records[game].Loses = reader.ReadInt(); 
            history.Records[game].Points = reader.ReadInt(); 
            history.Records[game].Kills = reader.ReadInt(); 
            history.Records[game].Deaths = reader.ReadInt(); 
            history.Records[game].Gold = reader.ReadInt(); 
        }
    }
}
