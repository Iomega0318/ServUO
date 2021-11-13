using Server.Items;
using Server.Mobiles;
using Server.OneTime;
using System.Collections.Generic;

namespace Server.RandomEvent
{
    public class GameRobe : Robe, IGameItem, IOneTime
    {
        public PlayerMobile PM { get; set; }
        public int OneTimeType { get; set; }
        public int TeamHue { get; set; }
        public int OrgKills { get; set; }

        [Constructable]
        public GameRobe(PlayerMobile player, int hue) : base(hue)
        {
            if (hue == 1175)
                Name = "Team Blackthorn";
            else
                Name = "Team British";

            ItemID = 0x2687;

            TeamHue = hue;
            OrgKills = player.Kills;

            PM = player;

            LootType = LootType.Blessed;

            OneTimeType = 3; //second : 3 = second, 4 = minute, 5 = hour, 6 = day (Pick a time interval 3-6)
        }

        public GameRobe(Serial serial) : base(serial)
        {
        }

        public override bool VerifyMove(Mobile from)
        {
            if (from is PlayerMobile)
                return false;
            else
                return true;
        }

        public override void OnDelete()
        {
            if (PM != null)
                PM.Kills = OrgKills;

            base.OnDelete();
        }

        public void OneTimeTick()
        {
            if (PM != null)
            {
                if (PM.Alive)
                    GameMain.EquipRobeCheck(PM, TeamHue);

                if (OrgKills == PM.Kills)
                    PM.Kills = PM.Kills + 15;

                if (!(PM.Backpack.FindItemByType(typeof(GamePlayer)) is GamePlayer tracker))
                    Delete();
                else
                {
                    if (PM.Backpack.FindItemByType(typeof(CTFFlag)) is CTFFlag flag)
                    {
                        if (Hue == TeamHue)
                            Hue = 1177;
                        else
                            Hue = TeamHue;
                    }
                    else
                    {
                        Hue = TeamHue;
                    }
                }
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(PM as Mobile);

            writer.Write(OneTimeType);
            writer.Write(TeamHue);
            writer.Write(OrgKills);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            PM = reader.ReadMobile() as PlayerMobile;

            OneTimeType = reader.ReadInt();
            TeamHue = reader.ReadInt();
            OrgKills = reader.ReadInt();
        }
    }
}
