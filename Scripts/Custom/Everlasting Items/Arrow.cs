using System;

namespace Server.Items
{
    public class EverlastingArrow : Item
    {
        [Constructable]
        public EverlastingArrow()
            : base(0xF3F)
        {
        }

        public EverlastingArrow(Serial serial)
            : base(serial)
        {
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
