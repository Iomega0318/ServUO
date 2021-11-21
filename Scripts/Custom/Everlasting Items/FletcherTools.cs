using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x1022, 0x1023)]
    public class EverlastingFletcherTools : EverlastingBaseTool
    {
		public override CraftSystem CraftSystem { get { return DefBowFletching.CraftSystem; } }
		public override int LabelNumber { get { return 1044559; } } // Fletcher's Tools
		
        [Constructable]
        public EverlastingFletcherTools()
            : base(0x1022)
        {
        }

        public EverlastingFletcherTools(Serial serial)
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
