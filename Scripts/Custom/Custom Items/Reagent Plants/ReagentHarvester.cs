using System;
using Server.Engines.Craft;
using Server.ContextMenus;

namespace Server.Items
{    
    public class ReagentHarvester : BaseTool
    {
        [Constructable]
        public ReagentHarvester()
            : base(0x26BB)
        {
            Name = "Reagent Harvester";
            Weight = 4.0;
            Layer = Layer.OneHanded;
        }

        [Constructable]
        public ReagentHarvester(int uses)
            : base(uses, 0x26BB)
        {
            Name = "Reagent Harvester";
            Weight = 4.0;
            Layer = Layer.OneHanded;
        }

        public ReagentHarvester(Serial serial)
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
