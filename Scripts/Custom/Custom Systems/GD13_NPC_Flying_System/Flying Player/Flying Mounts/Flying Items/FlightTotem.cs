using Server.Mobiles;

namespace Server.Items
{
    public class FlightTotem : Item
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public bool FlyLevel { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool FlyHover { get; set; }

        [Constructable]
        public FlightTotem() : base(0x2F5A)
        {
            this.Name = "Flight Totem";
            this.Hue = 1281;
            this.Visible = true;
            this.Movable = false;

            this.FlyLevel = false;
            this.FlyHover = false;
        }

        public FlightTotem(Serial serial) : base(serial)
        {
        }

        public override void OnSingleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            if (pm == null)
                return;

            if (pm.Flying == true)
            {
                if (FlyHover)
                {
                    FlyHover = true;
                    pm.SendMessage(38, $"Hoving at {pm.Z}");
                }
                else
                {
                    FlyHover = false;
                    pm.SendMessage(60, $"Flying off at {pm.Z}");
                }
            }
            else
            {
                this.Delete();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            if (pm == null)
                return;

            if (pm.Flying == true)
            {
                if (FlyLevel)
                {
                    if (!FlyHover)
                    {
                        FlyHover = true;
                        pm.SendMessage(38, $"Hoving at {pm.Z}");
                    }
                    else
                    {
                        FlyHover = false;
                        FlyLevel = false;
                        pm.SendMessage(38, $"Heading off at {pm.Z}");
                    }
                }
                else
                {
                    FlyLevel = true;
                    pm.SendMessage(60, $"Leveled off at {pm.Z}");
                }
            }
            else
            {
                this.Delete();
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
        }
    }
}
