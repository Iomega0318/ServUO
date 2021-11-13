using Server.Mobiles;
using Server.OneTime;

namespace Server.RandomEvent
{
    class Bouncer : Item, IGameItem, IOneTime
    {
        public int OneTimeType { get; set; }

        public PlayerMobile PM { get; set; }

        [Constructable]
        public Bouncer(PlayerMobile pm) : base(0x023B)
        {
            PM = pm;
            
            Name = "Player Bouncer";

            OneTimeType = 3;

            Movable = false;

            Hue = 1177;
        }

        public Bouncer(Serial serial) : base(serial)
        {
        }

        public void OneTimeTick()
        {
            if (PM.Combatant != null)
            {
                if (PM.Combatant is PlayerMobile)
                {
                    bool IsTeamPlayer = false;

                    PlayerMobile TeamPlayer = PM.Combatant as PlayerMobile;

                    if (GameMain.TeamOne.Contains(TeamPlayer) || GameMain.TeamTwo.Contains(TeamPlayer))
                        IsTeamPlayer = true;

                    if (IsTeamPlayer)
                    {
                        if (TeamPlayer.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer combatantgp)
                        {
                            if (PM.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer gp)
                            {
                                if (gp.IsTeamBritish != combatantgp.IsTeamBritish)
                                {
                                    PM.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                                    PM.PlaySound(0x543);

                                    TeamPlayer.MoveToWorld(gp.IsTeamBritish ? GameMain.TeamOneSpawnPoint : GameMain.TeamTwoSpawnPoint, GameMain.GameMap);

                                    TeamPlayer.FixedParticles(0x37C4, 3, 8, 0, 1176, 0, EffectLayer.Waist);
                                    TeamPlayer.PlaySound(0x543);

                                    Delete();
                                }
                            }
                        }
                    }
                }
            }
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
