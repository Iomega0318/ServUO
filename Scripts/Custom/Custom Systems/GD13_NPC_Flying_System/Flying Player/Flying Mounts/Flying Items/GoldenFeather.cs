using Server.Mobiles;
using Server.Mobiles.Flying.Player;

namespace Server.Items
{
    public class GoldenFeather : Item
    {
        [Constructable]
        public GoldenFeather() : base(0x1BD1)
        {
            this.Name = "Golden Feather";
            this.Hue = 1281;
        }

        public GoldenFeather(Serial serial) : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;

            Item ff = pm.Backpack.FindItemByType(typeof(FlightTotem));

            if (ff == null)
                pm.AddToBackpack(new FlightTotem());

            if (pm.Mount != null && pm.Mount is FlyingHiryu)
            {
                if (!pm.Flying)
                {
                    if (pm.CantWalk == false)
                    {
                        pm.CantWalk = true;

                        FlyingTimer f_timer = new FlyingTimer(pm);

                        f_timer.Start();
                    }
                }
                else
                {
                    pm.Flying = false;
                    pm.CantWalk = false;
                }
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
