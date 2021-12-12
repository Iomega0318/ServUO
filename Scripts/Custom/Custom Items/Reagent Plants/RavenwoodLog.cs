using System;

namespace Server.Items
{
    public class RavenwoodLog : Item
    {
        [Constructable]
        public RavenwoodLog()
            : base(0x1BDD)
        {
            this.Name = "Ravenwood Log";
            this.Movable = true;
            this.Stackable = false;
            this.Hue = 502;
        }

        public RavenwoodLog(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
