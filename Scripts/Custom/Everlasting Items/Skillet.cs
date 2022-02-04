using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingSkillet : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefCooking.CraftSystem;

        [Constructable]
        public EverlastingSkillet()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingSkillet(int uses)
            : base(uses, 0x97F)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Skillet";
            Hue = 1153;
        }

        public EverlastingSkillet(Serial serial)
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
