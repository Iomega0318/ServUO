using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingMortarPestle : BaseTool
    {
        [Constructable]
        public EverlastingMortarPestle()
            : base(0xE9B)
        {
        }

        public EverlastingMortarPestle(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem
        {
            get
            {
                return DefAlchemy.CraftSystem;
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
