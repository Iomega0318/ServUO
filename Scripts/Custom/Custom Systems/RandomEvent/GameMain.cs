using System;
using Server.Mobiles;
using System.Collections.Generic;
using Server.OneTime.Events;
using Server.Gumps;
using Server.Engines.PartySystem;

namespace Server.RandomEvent
{
    public static class GameMain
    {
        public static int GameCounter { get; set; }
        private static bool SentGameTypeToWorld { get; set; }

        //Game Position
        public static GamePosition GamePos { get; set; }

        public enum GamePosition
        {
            IsGameSetUp = 1,
            IsGameStart = 2,
            IsGameRunning = 3,
            IsGameEnding = 4,
            IsBetweenGames = 5
        };

        //Game Type
        public static GameTypes GameType { get; set; }

        public enum GameTypes
        {
            Capture_The_Flag = 1,
            Team_Death_Match = 2,
            Team_Elimination = 3,
            Slime_Death_Match = 4,
            Super_Death_Match = 5
        };

        //Game - Item(s)
        public static IGameItem GameItem { get; set; }
        public static List<IGameItem> GameItems { get; set; }
        public static List<IGameMobile> GameMobiles { get; set; }
        public static Point3D GameItemSpawnPoint { get; set; }

        //Teams - Players
        public static List<PlayerMobile> TeamOne { get; set; }
        private static Banker TeamOneBanker { get; set; }
        public static List<PlayerMobile> TeamTwo { get; set; }
        private static Banker TeamTwoBanker { get; set; }
        public static List<PlayerMobile> OptOut { get; set; }

        //Game Settings
        public static readonly Map GameMap = Map.Felucca;
        public static string GameRegion { get; set; }

        public static Point3D TeamOneSpawnPoint { get; set; }
        public static Point3D TeamTwoSpawnPoint { get; set; }

        public static readonly int GameSetUpDelay = 3;
        public static int GameLength { get; set; }
        public static readonly int GameResetDelay = 2;
        public static int NextGameDelay { get; set; }

        private static int TotalGameTime { get; set; }

        public static void Initialize()
        {
            CheckKeeperIsSpawned();

            GameCounter = 0;
            GameClockTimer = 0;

            SentGameTypeToWorld = false;

            GameItems = new List<IGameItem>();
            GameMobiles = new List<IGameMobile>();

            TeamOne = new List<PlayerMobile>();
            TeamTwo = new List<PlayerMobile>();
            OptOut = new List<PlayerMobile>();

            GameSetUp();
            
            OneTimeSecEvent.SecTimerTick += UpdateGameTime;
            EventSink.Logout += EventSink_Logout;
            EventSink.Crashed += EventSink_Crashed;
        }

        private static int GameClockTimer { get; set; }

        private static void UpdateGameTime(object sender, EventArgs e)
        {
            bool CheckMainGame = false;

            if (GameClockTimer >= 59)
            {
                GameCounter++;
                GameClockTimer = 0;
                CheckMainGame = true;
            }
            else
                GameClockTimer++;

            string time = "";

            if (GameClockTimer < 10)
                time = $"{GameCounter}:0{GameClockTimer} / ";
            else
                time = $"{GameCounter}:{GameClockTimer} / ";

            if (TeamOne.Count > 0)
            {
                foreach (PlayerMobile player in TeamOne)
                {
                    if (GamePos == GamePosition.IsGameSetUp)
                        player.SendGump(new GameClockGump(player, $"{time}{GameSetUpDelay}:00"));

                    if (GamePos == GamePosition.IsGameRunning)
                    {
                        if(GameType != GameTypes.Team_Elimination)
                            player.SendGump(new GameClockGump(player, $"{time}{GameLength}:00"));
                        else
                            player.SendGump(new GameClockGump(player, $"{time}{TeamTwo.Count}"));
                    }

                    if (GamePos == GamePosition.IsGameEnding)
                        player.SendGump(new GameClockGump(player, $"{time}{GameResetDelay}:00"));
                }
            }

            if (TeamTwo.Count > 0)
            {
                foreach (PlayerMobile player in TeamTwo)
                {
                    if (GamePos == GamePosition.IsGameSetUp)
                        player.SendGump(new GameClockGump(player, $"{time}{GameSetUpDelay}:00"));

                    if (GamePos == GamePosition.IsGameRunning)
                    {
                        if (GameType != GameTypes.Team_Elimination)
                            player.SendGump(new GameClockGump(player, $"{time}{GameLength}:00"));
                        else
                            player.SendGump(new GameClockGump(player, $"{time}{TeamOne.Count}"));
                    }

                    if (GamePos == GamePosition.IsGameEnding)
                        player.SendGump(new GameClockGump(player, $"{time}{GameResetDelay}:00"));
                }
            }

            if (CheckMainGame)
                UpdateGameEvent();
        }

        private static void CheckKeeperIsSpawned()
        {
            bool IsKeeperSpawned = false;

            foreach (Mobile mobile in World.Mobiles.Values)
            {
                if (mobile is KeeperOfEvents)
                {
                    IsKeeperSpawned = true;
                }
            }

            bool IsEventBookSpawned = false;

            foreach (Item item in World.Items.Values)
            {
                if (item is EventBook)
                {
                    IsEventBookSpawned = true;
                }
            }

            if (!IsKeeperSpawned)
            {
                KeeperOfEvents keeper = new KeeperOfEvents();

                keeper.MoveToWorld(new Point3D(1368, 1615, 51), Map.Trammel);
            }

            if (!IsEventBookSpawned)
            {
                EventBook book = new EventBook();

                book.MoveToWorld(new Point3D(1367, 1616, 56), Map.Trammel);
            }
        }

        private static void EventSink_Crashed(CrashedEventArgs e)
        {
            foreach (PlayerMobile player in TeamOne)
            {
                CatchPlayerReset(player);
            }

            foreach (PlayerMobile player in TeamTwo)
            {
                CatchPlayerReset(player);
            }

            WorldCleanUp();

            GameReset();
        }

        public static void EventSink_Logout(LogoutEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
                CatchPlayerReset(e.Mobile as PlayerMobile);
        }

        public static void CatchPlayerReset(PlayerMobile pm)
        {
            if (TeamOne.Contains(pm) || TeamTwo.Contains(pm))
            {
                ReturnPlayer(pm);
            }
        }

        public static void UpdateGameEvent()
        {
            if (GamePos == GamePosition.IsGameSetUp)
            {
                if (TeamOne.Count > 0 && TeamTwo.Count > 0 && GameCounter <= GameSetUpDelay)
                {
                    if (GameCounter == GameSetUpDelay)
                    {
                        foreach (Mobile mob in World.Mobiles.Values)
                        {
                            if (mob is PlayerMobile && mob.Alive && !mob.Deleted && mob.Map != Map.Internal)
                            {
                                PlayerMobile pm = mob as PlayerMobile;
                                
                                if (!(pm.Backpack.FindItemByType(typeof(QuestPlayer)) is QuestPlayer QP))
                                {
                                    if (pm.HasGump(typeof(GameGump)))
                                        pm.CloseGump(typeof(GameGump));
                                }
                                else
                                {
                                    pm.SendMessage(pm.Name + ", you are still on a quest and will not be invited to the next event!");
                                }
                            }
                        }

                        GamePos = GamePosition.IsGameStart;
                    }
                    else
                    {
                        if (GameSetUpDelay - GameCounter > 1)
                            SendMessageToBoth(53, "The event will be starting in " + (GameSetUpDelay - GameCounter) + " minutes!", 2);
                        else
                            SendMessageToBoth(37, "The event will be starting in " + (GameSetUpDelay - GameCounter) + " minute!", 2);
                    }
                }
                else
                {
                    if (TeamOne.Count > 0 && TeamTwo.Count > 0)
                    {
                        GameCounter = 0;

                        GameClockTimer = 0;
                    }

                    if (GameCounter < GameSetUpDelay)
                        SendMessageToBoth(53, "Event Status : Waiting on Players!", 2);
                    else
                        SendMessageToBoth(37, "Event Status : Waiting on Players!", 2);

                    SendMessageToBoth(53, "Total Players Joined ( " + (TeamOne.Count + TeamTwo.Count).ToString() + " )", 2);

                    bool SendGumps = false;
                    List<PlayerMobile> players = new List<PlayerMobile>();

                    int GetPlayerCount = 0; //future single player check, shard have enough players?

                    foreach (Mobile mob in World.Mobiles.Values)
                    {
                        if (mob is PlayerMobile && mob.Alive && !mob.Deleted && mob.Map != Map.Internal)
                        {
                            GetPlayerCount++;

                            players.Add(mob as PlayerMobile);
                            SendGumps = true;
                        }
                    }

                    if (SendGumps)
                    {
                        foreach (PlayerMobile player in players)
                        {
                            Party mp = Party.Get(player);

                            if (player.Young == false && !OptOut.Contains(player) && mp == null)
                            {
                                if (!TeamOne.Contains(player) && !TeamTwo.Contains(player))
                                {
                                    GameCallGump(player, 1);

                                    if (GameType == GameTypes.Capture_The_Flag)
                                        player.PlaySound(0x66E); //Cow Bell
                                    else
                                        player.PlaySound(0x2E7); //Drums Battle
                                }
                                else
                                {
                                    if (!player.HasGump(typeof(GameStoreGump)))
                                        player.SendGump(new GameStoreGump(player, false));
                                }
                            }
                        }

                        if (!SentGameTypeToWorld)
                        {
                            World.Broadcast(0x35, true, "New event available : " + GameType.ToString().Replace('_', ' ') + " : Match Length = " + GameLength.ToString() + " minutes");
                            SentGameTypeToWorld = true;
                        }
                    }
                }
            }

            if (GamePos == GamePosition.IsGameStart)
            {
                GameCounter = 0;

                GameClockTimer = 0;

                GameStart();

                GamePos = GamePosition.IsGameRunning;

                if (GameLength - GameCounter > 1 && GameType != GameTypes.Team_Elimination)
                    SendMessageToBoth(53, "Event Started : event ends in " + (GameLength - GameCounter) + " minutes!", 3);
                else
                    SendMessageToBoth(53, "Event Started : event ends when one team is eliminated!", 3);

                SendMessageToBoth(62, "Need supplies? The banker will be leaving in one minute!", 3);
            }

            if (GamePos == GamePosition.IsGameRunning)
            {
                if (TeamOneBanker != null || TeamTwoBanker != null)
                {
                    if (GameCounter >= 1)
                    {
                        DeleteBankers();

                        foreach (PlayerMobile player in TeamOne)
                        {
                            if (player.Hidden == true)
                                player.Hidden = false;
                        }

                        foreach (PlayerMobile player in TeamTwo)
                        {
                            if (player.Hidden == true)
                                player.Hidden = false;
                        }
                    }
                }

                if (HasPlayers())
                {
                    GameRunning();

                    if (GameType != GameTypes.Team_Elimination)
                    {
                        if (GameCounter != 0 && GameCounter < GameLength)
                        {
                            if (GameLength - GameCounter > 1)
                                SendMessageToBoth(53, "The event will be ending in " + (GameLength - GameCounter) + " minutes!", 3);
                            else
                                SendMessageToBoth(37, "The event will be ending in " + (GameLength - GameCounter) + " minute!", 3);
                        }

                        if (GameCounter >= GameLength)
                        {
                            GameCounter = 0;

                            GameClockTimer = 0;

                            if (GameItem != null)
                            {
                                Item gi = GameItem as Item;

                                gi.Delete();
                            }

                            GamePos = GamePosition.IsGameEnding;

                            GameEnd();
                        }
                    }
                    else
                    {
                        int HowManyEliminated = 0;
                        bool TeamOneEliminated = false;

                        foreach (PlayerMobile player in TeamOne)
                        {
                            if (player.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer PlayerTracker)
                            {
                                if (PlayerTracker.IsEliminated)
                                    HowManyEliminated++;
                            }
                        }

                        if (TeamOne.Count == HowManyEliminated)
                            TeamOneEliminated = true;

                        HowManyEliminated = 0;
                        bool TeamTwoEliminated = false;

                        foreach (PlayerMobile player in TeamTwo)
                        {
                            if (player.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer PlayerTracker)
                            {
                                if (PlayerTracker.IsEliminated)
                                    HowManyEliminated++;
                            }
                        }

                        if (TeamTwo.Count == HowManyEliminated)
                            TeamTwoEliminated = true;

                        if (TeamOneEliminated || TeamTwoEliminated)
                        {
                            GameCounter = 0;

                            GameClockTimer = 0;

                            GamePos = GamePosition.IsGameEnding;

                            GameEnd();
                        }
                    }
                }
            }

            if (GamePos == GamePosition.IsGameEnding)
            {
                if (HasPlayers())
                {
                    if (GameCounter >= GameResetDelay)
                    {
                        GameCounter = 0;

                        GameClockTimer = 0;

                        ReturnPlayers();

                        GamePos = GamePosition.IsBetweenGames;

                        GameZones.UpdateZoneTeleports(GameRegion, true);
                    }
                }
            }

            if (GamePos == GamePosition.IsBetweenGames)
            {
                if (GameCounter >= NextGameDelay)
                {
                    GameCounter = 0;

                    GameClockTimer = 0;

                    GameReset();
                }
                else
                {
                    WorldCleanUp();
                }
            }

            if (GameCounter > TotalGameTime + 5 && GamePos == GamePosition.IsGameSetUp)
            {
                WorldCleanUp();

                GameReset();
            }
        }

        public static bool HasPlayers()
        {
            if (TeamOne.Count < 1 && TeamTwo.Count < 1)
            {
                GamePos = GamePosition.IsBetweenGames;

                GameZones.UpdateZoneTeleports(GameRegion, true);

                GameCounter = 0;

                GameClockTimer = 0;

                return false;
            }
            else
            {
                return true;
            }
        }

        public static void GameSetUp()
        {
            WorldCleanUp();

            GamePos = GamePosition.IsGameSetUp;

            if (GameItems.Count > 0)
                GameItems.Clear();
            if (GameMobiles.Count > 0)
                GameMobiles.Clear();
            if (TeamOne.Count > 0)
                TeamOne.Clear();
            if (TeamTwo.Count > 0)
                TeamTwo.Clear();
            if (OptOut.Count > 0)
                OptOut.Clear();

            GameLength = Utility.RandomMinMax(5, 30);
            NextGameDelay = Utility.RandomMinMax(5, 15);

            TotalGameTime = GameSetUpDelay + GameLength + GameResetDelay + NextGameDelay;

            int PickRandomZone = Utility.RandomMinMax(0, 5);
            int PickRandomGame = Utility.RandomMinMax(1, 5); //comment out to force game type below

            //int PickRandomGame = 4; //Testing override game, uncomment and comment out the random above! 1 = CTF, 2 = TDM, 3 = TE, 4 = TS

            GameRegion = GameZones.Zones[PickRandomZone];

            TeamOneSpawnPoint = GameZones.SetTeamSpawnPoints(GameRegion, out Point3D GetLocation);
            TeamTwoSpawnPoint = GetLocation;

            GameType = (GameTypes)PickRandomGame;

            if (GameType == GameTypes.Capture_The_Flag)
            {
                GameItem = new CTFFlag();
                GameItemSpawnPoint = GameZones.GetItemSpawnPoint(GameRegion);
            }
        }

        public static void GameStart() 
        {
            GameZones.UpdateZoneTeleports(GameRegion, false);

            Point3D location = new Point3D(0, 0, 0);

            if (TeamOneBanker == null)
            {
                TeamOneBanker = new Banker
                {
                    CantWalk = true
                };
                TeamOneBanker.MoveToWorld(TeamOneSpawnPoint, GameMap);

                if (GameType == GameTypes.Super_Death_Match)
                {
                    EventSuperMob SuperMob = new EventSuperMob(true);

                    SuperMob.MoveToWorld(TeamOneSpawnPoint, GameMap);
                }
            }

            if (TeamTwoBanker == null)
            {
                TeamTwoBanker = new Banker
                {
                    CantWalk = true
                };
                TeamTwoBanker.MoveToWorld(TeamTwoSpawnPoint, GameMap);

                if (GameType == GameTypes.Super_Death_Match)
                {
                    EventSuperMob SuperMob = new EventSuperMob(false);

                    SuperMob.MoveToWorld(TeamTwoSpawnPoint, GameMap);
                }
            }

            foreach (PlayerMobile pm in TeamOne) //Send Team One to Spawn Point
            {
                if (pm.HasGump(typeof(GameStoreGump)))
                    pm.CloseGump(typeof(GameStoreGump));

                pm.AddToBackpack(new GamePlayer(pm, pm.X, pm.Y, pm.Z, pm.Map, "Team British"));

                EquipRobeCheck(pm, 1153);

                if (TeamOneSpawnPoint != location)
                    pm.MoveToWorld(TeamOneSpawnPoint, GameMap);

                pm.Hidden = true;

                pm.PlaySound(0x543);
            }

            foreach (PlayerMobile pm in TeamTwo) //Send Team Two to Spawn Point
            {
                if (pm.HasGump(typeof(GameStoreGump)))
                    pm.CloseGump(typeof(GameStoreGump));

                pm.AddToBackpack(new GamePlayer(pm, pm.X, pm.Y, pm.Z, pm.Map, "Team Blackthorn"));

                EquipRobeCheck(pm, 1175);

                if (TeamTwoSpawnPoint != location)
                    pm.MoveToWorld(TeamTwoSpawnPoint, GameMap);

                pm.Hidden = true;

                pm.PlaySound(0x543);
            }

            if (GameItemSpawnPoint != location)
            {
                if (GameItem != null)
                {
                    Item gi = GameItem as Item;
                    gi.MoveToWorld(GameItemSpawnPoint, GameMap);
                }
            }

            if (GameType == GameTypes.Slime_Death_Match)
            {
                List<Point3D> loc = new List<Point3D>();

                foreach (Mobile mobile in World.Mobiles.Values)
                {
                    if (mobile is PlayerMobile)
                    {
                        //Don't spawn on players? Will think on this!
                    }
                    else
                    {
                        if (mobile.Map == GameMap && mobile.Region.IsPartOf(GameRegion))
                        {
                            loc.Add(mobile.Location);
                        }
                    }
                }

                if (loc.Count > 0)
                {
                    foreach (Point3D point in loc)
                    {
                        WilsonSlime wilson = new WilsonSlime();
                        wilson.MoveToWorld(point, GameMap);
                        GameMobiles.Add(wilson);
                    }
                }

                if (GameMobiles.Count > 0)
                {
                    //good spawn
                }
                else
                {
                    //bad spawn
                    WilsonSlime wilson = new WilsonSlime();
                    wilson.MoveToWorld(GameItemSpawnPoint, GameMap);
                    GameMobiles.Add(wilson);
                }
            }
        }

        public static void GameRunning() //Keep players in/out of the game - check!
        {
            foreach (Mobile mobile in World.Mobiles.Values)
            {
                if (mobile is PlayerMobile)
                {
                    PlayerMobile pm = mobile as PlayerMobile;
                    
                    if (!(pm.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer player))
                        GameZones.CheckZoneKick(mobile as PlayerMobile, GameRegion);
                    else if (!GameZones.CheckZone(pm, GameRegion))
                    {
                        if (TeamOne.Contains(mobile as PlayerMobile))
                        {
                            mobile.MoveToWorld(TeamOneSpawnPoint, GameMap);
                        }
                        if (TeamTwo.Contains(mobile as PlayerMobile))
                        {
                            mobile.MoveToWorld(TeamTwoSpawnPoint, GameMap);
                        }
                    }

                    mobile.PlaySound(0x51B);
                }
            }
        }

        public static void GameEnd()
        {
            foreach (PlayerMobile player in TeamOne)
            {
                player.CloseAllGumps();

                HoldPlayer(player, true);
            }

            foreach (PlayerMobile player in TeamTwo)
            {
                player.CloseAllGumps();

                HoldPlayer(player, true);
            }

            GameScoreBoard();
        }

        public static void EquipRobeCheck(PlayerMobile pm, int hue)
        {
            Item getItem = pm.FindItemOnLayer(Layer.OuterTorso);

            if (getItem != null)
            {
                if (getItem is GameRobe)
                {
                    //good to go, already has robe on!
                }
                else
                {
                    pm.Backpack.DropItem(getItem);

                    EquipRobe(pm, hue);
                }
            }
            else
            {
                EquipRobe(pm, hue);
            }
        }

        private static void EquipRobe(PlayerMobile pm, int hue)
        {
            if (!(pm.Backpack.FindItemByType(typeof(GameRobe)) is GameRobe getRobe))
            {
                GameRobe robe = new GameRobe(pm, hue);

                pm.EquipItem(robe);
            }
            else
            {
                pm.EquipItem(getRobe);
            }
        }

        public static void ReturnPlayers()
        {
            List<PlayerMobile> AllPlayers = new List<PlayerMobile>();

            AllPlayers.AddRange(TeamOne);
            AllPlayers.AddRange(TeamTwo);

            foreach (PlayerMobile player in AllPlayers)
            {
                ReturnPlayer(player);
            }
        }

        public static void ReturnPlayer(PlayerMobile player)
        {
            HoldPlayer(player, false);

            player.CloseAllGumps();

            if (player.FindItemOnLayer(Layer.OuterTorso) is GameRobe robe)
            {
                robe.Delete();
            }

            if (player.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer PlayerTracker)
            {
                player.MoveToWorld(new Point3D(PlayerTracker.OldPoint), PlayerTracker.OldMap);

                PlayerTracker.Delete();

                player.PlaySound(0x51B);
            }
        }

        public static void GameReset()
        {
            GameCounter = 0;
            GameClockTimer = 0;

            SentGameTypeToWorld = false;

            DeleteBankers();

            GameItems.Clear();
            GameMobiles.Clear();

            TeamOne.Clear();
            TeamTwo.Clear();
            OptOut.Clear();

            GameSetUp();
        }

        public static void GameCallGump(PlayerMobile pm, int stage)
        {
            bool IsGump = pm.HasGump(typeof(GameGump));

            if (IsGump)
            {
                pm.CloseGump(typeof(GameGump));
            }

            Gump gump = new GameGump(stage);
            pm.SendGump(gump);
        }

        public static void GameScoreBoard()
        {
            int T1Score = 0;
            int T2Score = 0;

            foreach (PlayerMobile player in TeamOne)
            {
                GamePlayer tracker = player.Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;

                T1Score = T1Score + tracker.TotalPoints;

                player.PlaySound(0x532);
            }

            foreach (PlayerMobile player in TeamTwo)
            {
                GamePlayer tracker = player.Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;

                T2Score = T2Score + tracker.TotalPoints;

                player.PlaySound(0x532);
            }

            foreach (PlayerMobile player in TeamOne)
            {
                GamePlayer tracker = player.Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;

                if (T1Score > T2Score)
                    tracker.GameWon = true;
                else
                    tracker.GameWon = false;

                if (T1Score == T2Score)
                    tracker.GameWon = false;

                Gump scoreboard = new GameScoreboard(T1Score, T2Score);
                player.SendGump(scoreboard);

                Gump gamescore = new GameGump(4, T1Score, T2Score);
                player.SendGump(gamescore);

                GameRewards.GiveReward(tracker);
            }

            foreach (PlayerMobile player in TeamTwo)
            {
                GamePlayer tracker = player.Backpack.FindItemByType(typeof(GamePlayer)) as GamePlayer;

                if (T1Score < T2Score)
                    tracker.GameWon = true;
                else
                    tracker.GameWon = false;

                if (T1Score == T2Score)
                    tracker.GameWon = false;

                Gump scoreboard = new GameScoreboard(T1Score, T2Score);
                player.SendGump(scoreboard);

                Gump gamescore = new GameGump(4, T2Score, T1Score);
                player.SendGump(gamescore);

                GameRewards.GiveReward(tracker);
            }

            EventBook.TotalGamesPlayed++;

            if (T1Score < T2Score)
                World.Broadcast(0x35, true, "Team Blackthorn has Won, " + GameType.ToString().Replace('_', ' ') + ", with a score of " + T2Score);
            else if (T1Score > T2Score)
                World.Broadcast(0x35, true, "Team British has Won, " + GameType.ToString().Replace('_', ' ') + ", with a score of " + T1Score);
            else
                World.Broadcast(0x35, true, "Latest event was a tie, " + GameType.ToString().Replace('_', ' ') + ", with a score of " + T1Score);
        }

        public static void HoldPlayer(PlayerMobile pm, bool IsHolding)
        {
            pm.Blessed = IsHolding;
            pm.Hidden = IsHolding;

            if (GamePos == GamePosition.IsGameEnding || GamePos == GamePosition.IsBetweenGames)
                pm.Frozen = IsHolding;
        }

        public static void DeleteBankers()
        {
            if (TeamOneBanker != null)
                TeamOneBanker.Delete();

            if (TeamTwoBanker != null)
                TeamTwoBanker.Delete();
        }

        public static void WorldCleanUp()
        {
            foreach (Mobile mobile in World.Mobiles.Values)
            {
                if (mobile is PlayerMobile pm)
                {
                    if (pm.AccessLevel == AccessLevel.Player)
                    {
                        if (pm.Blessed && pm.Frozen)
                        {
                            HoldPlayer(pm, false);

                            if (pm.Kills == 15)
                                pm.Kills = 0;
                        }
                    }
                }
            }

            List<Item> gameitems = new List<Item>();

            foreach (Item item in World.Items.Values)
            {
                if (item is IGameItem)
                    gameitems.Add(item);
            }

            List<Mobile> gamemobiles = new List<Mobile>();

            foreach (Mobile mob in World.Mobiles.Values)
            {
                if (mob is IGameMobile)
                    gamemobiles.Add(mob);
            }

            if (gameitems.Count > 0)
            {
                foreach (Item item in gameitems)
                {
                    item.Delete();
                }
            }

            if (gamemobiles.Count > 0)
            {
                foreach (Mobile mob in gamemobiles)
                {
                    mob.Delete();
                }
            }

            DeleteBankers();

            foreach (string zone in GameZones.Zones)
            {
                GameZones.UpdateZoneTeleports(zone, true);
            }
        }

        public static void SendMessageToBoth(int color, string message, int stage)
        {
            foreach (PlayerMobile playerMobile in TeamOne)
            {
                playerMobile.SendMessage(color, message);

                GameCallGump(playerMobile, stage);
            }

            foreach (PlayerMobile playerMobile in TeamTwo)
            {
                playerMobile.SendMessage(color, message);

                GameCallGump(playerMobile, stage);
            }
        }
    }
}
