using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingMalletAndChisel : BaseTool
    {
        [Constructable]
        public EverlastingMalletAndChisel()
            : base(0x12B3)
        {
        }

        public EverlastingMalletAndChisel(Serial serial)
            : base(serial)
        {
        }

        public override CraftSystem CraftSystem
        {
            get
            {
                return DefMasonry.CraftSystem;
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
