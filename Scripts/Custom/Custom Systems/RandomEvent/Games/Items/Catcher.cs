using System.Collections.Generic;
using Server.Mobiles;

namespace Server.RandomEvent
{
    class Catcher : Item, IGameItem
    {
        public PlayerMobile PM { get; set; }

        [Constructable]
        public Catcher(PlayerMobile pm) : base(0x0DCA)
        {
            PM = pm;

            if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
                Name = "Flag Catcher";
            else
                Name = "Player Catcher";

            Hue = 1177;

            Movable = false;
        }

        public Catcher(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (PM != null && from as PlayerMobile != PM)
                return;

            bool IsMoved = false;

            if (GameMain.GamePos == GameMain.GamePosition.IsGameRunning)
            {
                List<PlayerMobile> AllPlayers = new List<PlayerMobile>();

                if (GameMain.TeamOne.Count > 0)
                    AllPlayers.AddRange(GameMain.TeamOne);
                if (GameMain.TeamTwo.Count > 0)
                    AllPlayers.AddRange(GameMain.TeamTwo);

                if (AllPlayers.Contains(from as PlayerMobile))
                {
                    if (GameMain.GameType == GameMain.GameTypes.Capture_The_Flag)
                    {
                        foreach (PlayerMobile player in AllPlayers)
                        {
                            if (player.Backpack.FindItemByType(typeof(CTFFlag)) is CTFFlag flag)
                            {
                                from.MoveToWorld(player.Location, player.Map);

                                PM.FixedParticles(0x375A, 1, 17, 9919, 1176, 7, EffectLayer.Waist);
                                PM.PlaySound(0x51B);

                                from.SendMessage(from.Name + ", you magically catch up to the flag holder!");
                                from.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                                from.PlaySound(0x51B);

                                IsMoved = true;
                            }
                        }

                        if (!IsMoved)
                        {
                            from.MoveToWorld(GameMain.GameItemSpawnPoint, GameMain.GameMap);

                            PM.FixedParticles(0x375A, 1, 17, 9919, 1176, 7, EffectLayer.Waist);
                            PM.PlaySound(0x51B);

                            from.SendMessage(from.Name + ", you magically catch up to the flag!");
                            from.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                            from.PlaySound(0x51B);

                            IsMoved = true;
                        }
                    }
                    else
                    {
                        if (PM.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer GP)
                        {
                            int rndPlayer = Utility.RandomMinMax(0, GameMain.TeamOne.Count - 1);
                            int counter = 0;

                            if (GP.IsTeamBritish)
                            {
                                foreach (PlayerMobile GPlayer in GameMain.TeamTwo)
                                {
                                    if (rndPlayer == counter)
                                    {
                                        from.MoveToWorld(GPlayer.Location, GPlayer.Map);

                                        PM.FixedParticles(0x375A, 1, 17, 9919, 1176, 7, EffectLayer.Waist);
                                        PM.PlaySound(0x51B);

                                        from.SendMessage(from.Name + ", you magically catch up to a player on the other team!");
                                        from.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                                        from.PlaySound(0x51B);
                                        IsMoved = true;
                                    }
                                    counter++;
                                }
                            }
                            else
                            {
                                foreach (PlayerMobile GPlayer in GameMain.TeamOne)
                                {
                                    if (rndPlayer == counter)
                                    {
                                        from.MoveToWorld(GPlayer.Location, GPlayer.Map);

                                        PM.FixedParticles(0x375A, 1, 17, 9919, 1176, 7, EffectLayer.Waist);
                                        PM.PlaySound(0x51B);

                                        from.SendMessage(from.Name + ", you magically catch up to a player on the other team!");
                                        from.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                                        from.PlaySound(0x51B);
                                        IsMoved = true;
                                    }
                                    counter++;
                                }
                            }
                        }
                    }
                }

                AllPlayers.Clear();
            }
            else
            {
                from.SendMessage(from.Name + ", you can only use that while the game is active!");
            }

            if (IsMoved)
                Delete();
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(PM as Mobile);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            PM = reader.ReadMobile() as PlayerMobile;
        }
    }
}
