using System;
using Server.Engines.Craft;

namespace Server.Items
{
    [FlipableAttribute(0x13E3, 0x13E4)]
    public class EverlastingBlacksmithHammer : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefBlacksmithy.CraftSystem;

        [Constructable]
        public EverlastingBlacksmithHammer()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingBlacksmithHammer(int uses)
            : base(uses, 0x13E3)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Blacksmith's Hammer";
            Hue = 1153;
        }

        public EverlastingBlacksmithHammer(Serial serial)
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
