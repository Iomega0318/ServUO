using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingSewingKit : BaseTool
    {
        [Constructable]
        public EverlastingSewingKit()
            : base(0xF9D)
        {
        }

        public EverlastingSewingKit(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem
        {
            get
            {
                return DefTailoring.CraftSystem;
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
