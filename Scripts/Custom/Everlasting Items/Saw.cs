using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x1034, 0x1035)]
    public class EverlastingSaw : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefCarpentry.CraftSystem;

        [Constructable]
        public EverlastingSaw()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingSaw(int uses)
            : base(uses, 0x1034)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Saw";
            Hue = 1153;
        }

        public EverlastingSaw(Serial serial)
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
