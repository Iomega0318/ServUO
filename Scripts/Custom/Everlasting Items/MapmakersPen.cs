using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x0FBF, 0x0FC0)]
    public class EverlastingMapmakersPen : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefCartography.CraftSystem;

        [Constructable]
        public EverlastingMapmakersPen()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingMapmakersPen(int uses)
            : base(uses, 0x0FBF)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Mapmakers Pen";
            Hue = 1153;
        }

        public EverlastingMapmakersPen(Serial serial)
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
