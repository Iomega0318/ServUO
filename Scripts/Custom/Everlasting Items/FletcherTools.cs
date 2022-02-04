using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x1022, 0x1023)]
    public class EverlastingFletcherTools : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefBowFletching.CraftSystem;

        [Constructable]
        public EverlastingFletcherTools()
            : this(1)
        {
            Weight = 0.0;
        }

        [Constructable]
        public EverlastingFletcherTools(int uses)
            : base(uses, 0x1022)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Fletcher's Tools";
            Hue = 1153;
        }

        public EverlastingFletcherTools(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
