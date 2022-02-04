using Server.Engines.Harvest;

namespace Server.Items
{
    public class EverlastingShovel : BaseEverlastingHarvestTool
    {
        public override HarvestSystem HarvestSystem => Mining.System;

        [Constructable]
        public EverlastingShovel()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingShovel(int uses)
            : base(uses, 0xF39)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Shovel";
            Hue = 1153;
        }

        public EverlastingShovel(Serial serial)
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
