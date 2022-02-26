using System;

namespace Server.Items
{
    public class GateHueTicket : Item
    {
        [Constructable]
        public GateHueTicket()
            : this(1)
        {
        }

        [Constructable]
        public GateHueTicket(int amount)
            : base(0x14F0)
        {
			this.Name = "Gate Hue Ticket";
            this.Weight = 1.0;
            this.Amount = amount;
            this.Hue = 73;
			this.LootType = LootType.Blessed;
        }

        public GateHueTicket(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1027199;
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