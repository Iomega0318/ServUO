using System;
using Server.Engines.Craft;

namespace Server.Items
{
    public class EverlastingSewingKit : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefTailoring.CraftSystem;

        [Constructable]
        public EverlastingSewingKit()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingSewingKit(int uses)
            : base(uses, 0xF9D)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Sewing Kit";
            Hue = 1153;
        }

        public EverlastingSewingKit(Serial serial)
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
