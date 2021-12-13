using System;
using Server.Engines.Craft;
using Server.ContextMenus;

namespace Server.Items
{    
    public class RavenwoodAxe : BaseTool
    {
        [Constructable]
        public RavenwoodAxe()
            : this(Utility.RandomMinMax(40, 60))
        {
        }

        [Constructable]
        public RavenwoodAxe(int uses)
            : base(uses, 0xF43)
        {
            Name = "Ravenwood Axe";
            Hue = 502;
            Weight = 4.0;
            Layer = Layer.OneHanded;
        }

        public RavenwoodAxe(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
        }

        public override CraftSystem CraftSystem { get; }
        
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
