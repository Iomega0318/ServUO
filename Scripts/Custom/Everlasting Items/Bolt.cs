using System;

namespace Server.Items
{
    public class EverlastingBolt : Item
    {				
        [Constructable]
        public EverlastingBolt()
            : base(0x1BFB)
        {
        }

        public EverlastingBolt(Serial serial)
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
