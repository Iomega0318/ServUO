using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingMortarPestle : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefAlchemy.CraftSystem;

        [Constructable]
        public EverlastingMortarPestle()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingMortarPestle(int uses)
            : base(uses, 0xE9B)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Mortar and Pestle";
            Hue = 1153;
        }

        public EverlastingMortarPestle(Serial serial)
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
