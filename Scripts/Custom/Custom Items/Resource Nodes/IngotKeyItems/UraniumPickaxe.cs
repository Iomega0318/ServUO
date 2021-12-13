using System;
using Server.Engines.Craft;
using Server.ContextMenus;

namespace Server.Items
{
    public class UraniumPickaxe : BaseTool
    {
        [Constructable]
        public UraniumPickaxe()
            : this(Utility.RandomMinMax(40, 60))
        {
        }

        [Constructable]
        public UraniumPickaxe(int uses)
            : base(uses, 0xE86)
        {
            Name = "Uranium Pickaxe";
            Hue = 268;
            Weight = 4.0;
            Layer = Layer.OneHanded;
        }

        public UraniumPickaxe(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
        }

        public override CraftSystem CraftSystem { get; }

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

