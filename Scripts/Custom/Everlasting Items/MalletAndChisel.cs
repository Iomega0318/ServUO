using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingMalletAndChisel : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefMasonry.CraftSystem;

        [Constructable]
        public EverlastingMalletAndChisel()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingMalletAndChisel(int uses)
            : base(uses, 0x12B3)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Mallet And Chisel";
            Hue = 1153;
        }

        public EverlastingMalletAndChisel(Serial serial)
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
