using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class NewbieArmor : Bag
    {
        [Constructable]
        public NewbieArmor() : this(1)
        {
            Movable = true;
            Name = "A Bag Of Newbie Armor";
            Hue = 1910;
        }
        [Constructable]
        public NewbieArmor(int amount)
        {
            DropItem(new NewbieHat());
            DropItem(new NewbieChest());
            DropItem(new NewbieGloves());
            DropItem(new NewbieGorget());
            DropItem(new NewbieLegs());
            DropItem(new NewbieArms());
            DropItem(new NewbieSandals());
        }

        public NewbieArmor(Serial serial) : base(serial)
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
