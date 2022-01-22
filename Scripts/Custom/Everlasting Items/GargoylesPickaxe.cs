using System;
using Server.Engines.Harvest;

namespace Server.Items
{
    public class EverlastingGargoylesPickaxe : BaseAxe
    {

        [Constructable]
        public EverlastingGargoylesPickaxe()
            : base(0xE85)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Gargoyles Pickaxe";
            Hue = 1153;
        }

        public EverlastingGargoylesPickaxe(Serial serial)
            : base(serial)
        {
        }
        public override HarvestSystem HarvestSystem
        {
            get
            {
                return Mining.System;
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
