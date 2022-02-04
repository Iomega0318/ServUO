using System;

namespace Server.Items
{
    public class UraniumOre : BaseOre
    {
        [Constructable]
        public UraniumOre()
            : this(1)
        {
        }

        [Constructable]
        public UraniumOre(int amount)
            : base(CraftResource.Uranium, amount)
        {
            Name = "Uranium Ore"; //daat99 OWLTR - custom resource name
        }

        public UraniumOre(bool fixedSize)
            : this(1)
        {
            if (fixedSize)
                ItemID = 0x19B8;
        }

        public UraniumOre(Serial serial)
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

        public override BaseIngot GetIngot()
        {
            return new UraniumIngot();
        }
    }

    [FlipableAttribute(0x1BF2, 0x1BEF)]
    public class UraniumIngot : BaseIngot
    {
        [Constructable]
        public UraniumIngot()
            : this(1)
        {
        }

        [Constructable]
        public UraniumIngot(int amount)
            : base(CraftResource.Uranium, amount)
        {
            Name = "Uranium Ingots"; //daat99 OWLTR - resource name
        }

        public UraniumIngot(Serial serial)
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
