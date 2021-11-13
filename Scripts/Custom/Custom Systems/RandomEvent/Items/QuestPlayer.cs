using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.OneTime;

namespace Server.RandomEvent
{
    public class QuestPlayer : Item, IOneTime
    {
        public PlayerMobile PM { get; set; }

        public int OneTimeType { get; set; }

        public int GameMobsKilled { get; set; }
        public int QuestTimer { get; set; }
        private bool IsLoading { get; set; }

        public QuestTypes QuestType { get; set; }

        public enum QuestTypes
        {
            GetXNumberEasyMobiles,
            GetXNumberHardMobiles
        }

        [Constructable]
        public QuestPlayer(PlayerMobile pm, int time) : base(0x2F5B)
        {
            Name = pm.Name + ", Quest Tracker";

            Movable = false;
            BlessedFor = pm;
            Visible = false;
            Hue = 1153;

            PM = pm;

            OneTimeType = 4; //minute : 3 = second, 4 = minute, 5 = hour, 6 = day (Pick a time interval 3-6)

            QuestTimer = time; //tesing override
            //QuestTimer = 3; //tesing override

            IsLoading = false;
            GameMobsKilled = 0;
            GetValidKills = 0;

            QuestType = (QuestTypes)Utility.RandomMinMax(0, 1);

            EventSink.OnKilledBy += OnKilledBy;

            OneTimeTick();
        }

        public int GetValidKills { get; set; }

        private void OnKilledBy(OnKilledByEventArgs e)
        {
            if (e.KilledBy is PlayerMobile && e.Killed is BaseCreature)
            {
                if (QuestType == QuestTypes.GetXNumberEasyMobiles)
                {
                    if (e.Killed.Name == RandomQuestEasyMob)
                    {
                        GetValidKills++;
                        PM.SendMessage(53, PM.Name + ", you have killed " + RandomQuestEasyMob + ", your total killed is at " + GetValidKills.ToString());
                        PM.PlaySound(0x5B5);
                    }
                }

                if (QuestType == QuestTypes.GetXNumberHardMobiles)
                {
                    if (e.Killed.Name == RandomQuestHardMob)
                    {
                        GetValidKills++;
                        PM.SendMessage(53, PM.Name + ", you have killed " + RandomQuestHardMob + ", your total killed is at " + GetValidKills.ToString());
                        PM.PlaySound(0x5B5);
                    }
                }
            }
        }

        public QuestPlayer(Serial serial) : base(serial)
        {
        }

        private string RandomQuestEasyMob { get; set; }
        private string RandomQuestHardMob { get; set; }

        private readonly List<string> EBCnames = new List<string> { "a troll", "a rat", "a cow", "a brown bear", "a slime", "a snake", "a walrus", "a tropical bird", "a polar bear", "a skeleton", "a reaper" };
        private readonly List<string> HBCnames = new List<string> { "a dragon", "a white wyrm", "a terathan avenger", "a frenzied ostard", "a lich", "a lich lord", "a sea serpent", "a gazer", "a kraken", "a skeletal knight", "a nightmare" };
        
        public void OneTimeTick()
        {
            if (QuestTimer > 0)
            {
                bool IsMobileInWorld = false;

                if (QuestType == QuestTypes.GetXNumberEasyMobiles)
                {
                    if (RandomQuestEasyMob == null)
                    {
                        while (!IsMobileInWorld)
                        {
                            int GetRandomMobile = Utility.RandomMinMax(0, 10);

                            RandomQuestEasyMob = EBCnames[GetRandomMobile];

                            foreach (Mobile mob in World.Mobiles.Values)
                            {
                                if (mob.Name == RandomQuestEasyMob)
                                    IsMobileInWorld = true;
                            }
                        }
                    }

                    if (QuestTimer > 1)
                        PM.SendMessage(53, PM.Name + $", find and suppress as many{RandomQuestEasyMob.TrimStart('a')}'s as you can in " + QuestTimer + " minutes");
                    else
                        PM.SendMessage(37, PM.Name + $", find and suppress as many{RandomQuestEasyMob.TrimStart('a')}'s as you can in " + QuestTimer + " minute");
                }
                else
                {
                    if (RandomQuestHardMob == null)
                    {
                        while (!IsMobileInWorld)
                        {
                            int GetRandomMobile = Utility.RandomMinMax(0, 10);

                            RandomQuestHardMob = HBCnames[GetRandomMobile];

                            foreach (Mobile mob in World.Mobiles.Values)
                            {
                                if (mob.Name == RandomQuestHardMob)
                                    IsMobileInWorld = true;
                            }
                        }
                    }

                    if (QuestTimer > 1)
                        PM.SendMessage(53, PM.Name + $", find and suppress as many{RandomQuestHardMob.TrimStart('a')}'s as you can in " + QuestTimer + " minutes");
                    else
                        PM.SendMessage(37, PM.Name + $", find and suppress as many{RandomQuestHardMob.TrimStart('a')}'s as you can in " + QuestTimer + " minute");
                }

                QuestTimer--;

                PM.PlaySound(0x5B6);
            }
            else
            {
                if (!IsLoading)
                {
                    if (QuestType == QuestTypes.GetXNumberEasyMobiles)
                    {
                        if (GetValidKills > 0)
                            PM.SendMessage(53, PM.Name + $", you suppressed {GetValidKills} " + RandomQuestEasyMob.TrimStart('a') + "'s");
                        else
                            PM.SendMessage(37, PM.Name + $", you suppressed 0 " + RandomQuestEasyMob.TrimStart('a') + "'s");

                        GameMobsKilled = GetValidKills;
                    }

                    if (QuestType == QuestTypes.GetXNumberHardMobiles)
                    {
                        if (GetValidKills > 0)
                            PM.SendMessage(53, PM.Name + $", you suppressed {GetValidKills} " + RandomQuestHardMob.TrimStart('a') + "'s");
                        else
                            PM.SendMessage(27, PM.Name + $", you suppressed 0 " + RandomQuestHardMob.TrimStart('a') + "'s");

                        GameMobsKilled = GetValidKills * 5;
                    }

                    if (GameMobsKilled < 0)
                        GameMobsKilled = 0;
                }

                Delete();
            }
        }

        public override void OnDelete()
        {
            if (!IsLoading)
                SendGameRecords(PM, this);

            EventSink.OnKilledBy -= OnKilledBy;

            base.OnDelete();
        }

        public void SendGameRecords(PlayerMobile pm, QuestPlayer qp)
        {
            if (pm != null)
            {
                GameHistory history = new GameHistory
                {
                    Player = pm,

                    GameTokens = 1 + GameMobsKilled,
                };

                pm.SendMessage(62, PM.Name + $", you are rewarded {1 + GameMobsKilled} Game Token's");

                pm.PlaySound(0x5B5);

                EventBook.UpdateGameHistory(history);
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(PM as Mobile);

            writer.Write(OneTimeType);

            writer.Write(RandomQuestEasyMob);
            writer.Write(RandomQuestHardMob);

    }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            PM = reader.ReadMobile() as PlayerMobile;

            OneTimeType = reader.ReadInt();

            RandomQuestEasyMob = reader.ReadString();
            RandomQuestHardMob = reader.ReadString();

            QuestTimer = 0;
            IsLoading = true;
            OneTimeTick();
        }
    }
}
