using Server.Items;
using Server.Mobiles;

namespace Server.RandomEvent
{
    public class KeeperOfEvents : BaseCreature
    {
        [Constructable]
        public KeeperOfEvents() : base(AIType.AI_Mystic, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Title = "the keeper of events";

            InitStats(31, 41, 51);

            SpeechHue = 53;

            Hue = Utility.RandomSkinHue();

            if (Female = Utility.RandomBool())
            {
                Body = 0x191;
                Name = NameList.RandomName("female");
            }
            else
            {
                Body = 0x190;
                Name = NameList.RandomName("male");
            }

            Utility.AssignRandomHair(this);

            HairHue = 1177;

            AddItem(new LongPants(1153));
            AddItem(new Robe(1175));
            AddItem(new WizardsHat(1153));
            AddItem(new Sandals(1175));

            Container pack = new Backpack();

            pack.DropItem(new Gold(10, 50));

            pack.Movable = false;

            AddItem(pack);

            ThinkDelay = 0;

            CantWalk = true;
            Blessed = true;
        }

        public KeeperOfEvents(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (EventBook.BaseGameHistory != null && EventBook.BaseGameHistory.Count > 0)
            {
                bool HasRecord = false;
                GameHistory Record = null;

                foreach (GameHistory history in EventBook.BaseGameHistory)
                {
                    if (history.Player == from as PlayerMobile)
                    {
                        Record = history;
                        HasRecord = true;
                    }
                }

                if (HasRecord)
                {
                    from.SendMessage(0, $"-Lifetime Stats-");
                    from.SendMessage(0, $"Total Games Played = {Record.TotalWins + Record.TotalLoses}");
                    from.SendMessage(0, $"As Team British = {Record.TeamBritish}");
                    from.SendMessage(0, $"As Team Blackthorn = {Record.TeamBlackthorn}");
                    from.SendMessage(0, $"Game Token's = {Record.GameTokens}");
                
                    from.SendMessage(0, $"-Overall Record-");
                    from.SendMessage(0, $"Overall Wins = {Record.TotalWins}");
                    from.SendMessage(0, $"Overall Loses = {Record.TotalLoses}");
                    from.SendMessage(0, $"Overall Points = {Record.TotalPoints}");
                    from.SendMessage(0, $"Overall Kills = {Record.TotalKills}");
                    from.SendMessage(0, $"Overall Deaths = {Record.TotalDeaths}");
                    from.SendMessage(0, $"Overall Gold Won = {Record.TotalGold}");

                    from.SendMessage(0, $"[Capture the Flag Record]");
                    SendRecordMessages(from, Record, GameMain.GameTypes.Capture_The_Flag);

                    from.SendMessage(0, $"[Team Death Match Record]");
                    SendRecordMessages(from, Record, GameMain.GameTypes.Team_Death_Match);

                    from.SendMessage(0, $"[Team Elimination Record]");
                    SendRecordMessages(from, Record, GameMain.GameTypes.Team_Elimination);

                    from.SendMessage(0, $"[Team Slime Record]");
                    SendRecordMessages(from, Record, GameMain.GameTypes.Slime_Death_Match);

                    from.SendMessage(0, $"[Super Death Match Record]");
                    SendRecordMessages(from, Record, GameMain.GameTypes.Super_Death_Match);

                    Say(from.Name + ", you have been busy, open journal to review your record!");
                }
                else
                {
                    Say(from.Name + ", you have not played any games, we have no records on file!");
                }
            }
            else
            {
                Say(from.Name + ", you have not played any games, we have no records on file!");
            }

            base.OnDoubleClick(from);   
        }

        public void SendRecordMessages(Mobile from, GameHistory history, GameMain.GameTypes game)
        {
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Wins = {history.Records[(int)game].Wins}");
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Loses = {history.Records[(int)game].Loses}");
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Points = {history.Records[(int)game].Points}");
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Kills = {history.Records[(int)game].Kills}");
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Deaths = {history.Records[(int)game].Deaths}");
            from.SendMessage(0, $"{game.ToString().Replace('_', ' ')} Gold Won = {history.Records[(int)game].Gold}");
        }

        private int ThinkDelay { get; set; }

        public override void OnThink()
        {
            if (ThinkDelay < 1)
            {
                ThinkDelay = 200;

                foreach (Mobile mobile in GetMobilesInRange(3))
                {
                    if (mobile is PlayerMobile)
                    {
                        PlayerMobile pm = mobile as PlayerMobile;

                        SpeechHue = 53;

                        SayTo(pm, pm.Name + ", come to review the top game leaders? Help yourself, I keep perfect records");
                    }
                }
            }
            else
            {
                ThinkDelay--;

                base.OnThink();
            }
        }

        public override bool ClickTitle
        {
            get
            {
                return false;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            ThinkDelay = 0;
        }
    }
}
