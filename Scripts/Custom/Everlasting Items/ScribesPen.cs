using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x0FBF, 0x0FC0)]
    public class EverlastingScribesPen : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefInscription.CraftSystem;

        [Constructable]
        public EverlastingScribesPen()
            : this(1)
        {
        }
		
        [Constructable]
        public EverlastingScribesPen(int uses)
            : base(uses, 0x0FBF)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Scribes Pen";
            Hue = 1153;
        }

        public EverlastingScribesPen(Serial serial)
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
