using Server.Mobiles;
using Server.OneTime;
using System.Collections.Generic;
using System.Linq;

namespace Server.RandomEvent
{
    public class GamePlayer : Item, IGameItem, IOneTime
    {
        public PlayerMobile PM { get; set; }

        public int OneTimeType { get; set; }
        
        public Map OldMap { get; set; }

        public Point3D OldPoint { get; set; }

        public bool GameWon { get; set; }
        public int TotalPoints { get; set; }
        public int TotalKills { get; set; }
        public int TotalDeaths { get; set; }
        public int GameMobsKilled { get; set; }

        public bool IsTeamBritish { get; set; }
        public GameMain.GameTypes Game = GameMain.GameType;
        public bool IsEliminated { get; set; }

        [Constructable]
        public GamePlayer(PlayerMobile pm, int x, int y, int z, Map map, string team) : base(0x2F5B)
        {
            Name = pm.Name + ", Game Tracker ( " + team + " )";

            Movable = false;
            BlessedFor = pm;
            Visible = false;
            Hue = 1153;

            PM = pm;

            OldPoint = new Point3D(x, y, z);

            OldMap = map;

            OneTimeType = 3; //second : 3 = second, 4 = minute, 5 = hour, 6 = day (Pick a time interval 3-6)

            GameWon = false;
            TotalPoints = 0;
            TotalKills = 0;
            TotalDeaths = 0;
            IsEliminated = false;
        }

        public GamePlayer(Serial serial) : base(serial)
        {
        }

        private Point3D PlayerOldLoc;
        private PlayerMobile mob;

        public void OneTimeTick()
        {
            if (Hue == 1175)
                Hue = 1153;
            else
                Hue = 1175;

            if (RootParent != null)
            {
                IsTeamBritish = GameMain.TeamOne.Contains(PM);

                if (IsEliminated == true)
                    GameMain.HoldPlayer(PM, true);

                if (PM.Alive)
                {
                    if (PM.Combatant != null && PM.Combatant is PlayerMobile)
                        mob = PM.Combatant as PlayerMobile;
                    else
                        mob = null;

                    if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
                    {
                        if (PlayerOldLoc != PM.Location)
                        {
                            IEnumerable<Item> items = from c in PM.GetItemsInRange(1)
                                                      where c is CTFFlag
                                                      select c as CTFFlag;

                            foreach (Item item in items)
                            {
                                PM.AddToBackpack(item);

                                GameMain.SendMessageToBoth(37, "Flag Picked Up By : " + PM.Name, 3);
                            }
                        }

                        Item Flag = PM.Backpack.FindItemByType(typeof(CTFFlag));

                        if (Flag != null)
                        {
                            TotalPoints++;
                        }
                    }
                }
                else if (mob != null)
                {
                    if (mob.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer gp)
                    {
                        gp.TotalKills++;
                        gp.TotalPoints = gp.TotalPoints + 100;
                        GameMain.SendMessageToBoth(37, PM.Name + " has been killed by " + gp.PM.Name, 3);
                    }

                    if (GameMain.GameType != GameMain.GameTypes.Team_Elimination)
                    {
                        if (GameMain.TeamOne.Contains(PM))
                        {
                            PM.MoveToWorld(GameMain.TeamOneSpawnPoint, GameMain.GameMap);
                        }
                        else
                        {
                            PM.MoveToWorld(GameMain.TeamTwoSpawnPoint, GameMain.GameMap);
                        }

                        TotalDeaths++;
                        PM.Resurrect();
                        PM.Hidden = true;
                        GameMain.GameCallGump(PM, 3);
                    }
                    else
                    {
                        GameMain.SendMessageToBoth(37, PM.Name + " has been eliminated from the match by " + mob.Name, 3);
                        IsEliminated = true;
                        TotalDeaths++;
                        PM.Resurrect();
                        PM.Blessed = true;
                        PM.Hidden = true;
                        GameMain.GameCallGump(PM, 3);
                        PM.SendMessage(PM.Name + ", please wait for the match to end!");
                        PM.SendMessage(PM.Name + ", you can follow along hidden from play!");
                        GameMain.UpdateGameEvent();
                    }
                }
                else
                {
                    if (GameMain.TeamOne.Contains(PM))
                    {
                        PM.MoveToWorld(GameMain.TeamOneSpawnPoint, GameMain.GameMap);
                    }
                    else
                    {
                        PM.MoveToWorld(GameMain.TeamTwoSpawnPoint, GameMain.GameMap);
                    }
                    
                    PM.Resurrect();
                    PM.Hidden = true;
                    GameMain.GameCallGump(PM, 3);
                }
            }
        }

        public override void OnDelete()
        {
            SendGameRecords(PM, this);

            base.OnDelete();
        }

        public void SendGameRecords(PlayerMobile pm, GamePlayer gp)
        {
            if (GameMain.GamePos == GameMain.GamePosition.IsGameEnding)
            {
                GameHistory history = new GameHistory
                {
                    Player = pm,

                    GameTokens = (gp.GameWon ? 10 : 5) + GameMobsKilled,

                    TeamBritish = gp.IsTeamBritish ? 1 : 0,
                    TeamBlackthorn = gp.IsTeamBritish ? 0 : 1,

                    //Overall Totals
                    TotalWins = gp.GameWon ? 1 : 0,
                    TotalLoses = gp.GameWon ? 0 : 1,
                    TotalPoints = gp.TotalPoints,
                    TotalKills = gp.TotalKills,
                    TotalDeaths = gp.TotalDeaths,
                    TotalGold = gp.TotalGold
                };
                
                UpdateGameRecord(history, gp, (int)gp.Game);

                EventBook.UpdateGameHistory(history);
            }
            else
            {
                if (GameMain.TeamOne.Contains(PM))
                {
                    GameMain.TeamOne.Remove(PM);
                }
                else if (GameMain.TeamTwo.Contains(PM))
                {
                    GameMain.TeamTwo.Remove(PM);
                }
            }
        }

        public void UpdateGameRecord(GameHistory history, GamePlayer gp, int game)
        {
            history.Records[game].Wins = gp.GameWon ? 1 : 0;
            history.Records[game].Loses = gp.GameWon ? 0 : 1;
            history.Records[game].Points = gp.TotalPoints;
            history.Records[game].Kills = gp.TotalKills;
            history.Records[game].Deaths = gp.TotalDeaths;
            history.Records[game].Gold = gp.TotalGold;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(PM as Mobile);

            writer.Write(OneTimeType);

            writer.Write(OldMap);

            writer.Write(OldPoint);

            writer.Write(GameWon);
            writer.Write(TotalPoints);
            writer.Write(TotalKills);
            writer.Write(TotalDeaths);

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            PM = reader.ReadMobile() as PlayerMobile;

            OneTimeType = reader.ReadInt();

            OldMap = reader.ReadMap();

            OldPoint = reader.ReadPoint3D();

            GameWon = reader.ReadBool();
            TotalPoints = reader.ReadInt();
            TotalKills = reader.ReadInt();
            TotalDeaths = reader.ReadInt();
        }
    }
}
