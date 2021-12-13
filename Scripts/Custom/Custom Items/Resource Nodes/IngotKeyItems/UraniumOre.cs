using System;

namespace Server.Items
{
    public class UraniumOre : Item
    {
        [Constructable]
        public UraniumOre()
            : base(0x19B8)
        {
            this.Name = "Uranium Ore";
            this.Movable = true;
            this.Stackable = false;
            this.Hue = 268;
        }

        public UraniumOre(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
