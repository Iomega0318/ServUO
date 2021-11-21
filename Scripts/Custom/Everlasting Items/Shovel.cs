using System;
using Server.Engines.Harvest;

namespace Server.Items
{
    public class EverlastingShovel : BaseHarvestTool
    {
		public override HarvestSystem HarvestSystem { get { return Mining.System; } }
		
        [Constructable]
        public EverlastingShovel()
            : base(0xF39)
        {
        }

        public EverlastingShovel(Serial serial)
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
