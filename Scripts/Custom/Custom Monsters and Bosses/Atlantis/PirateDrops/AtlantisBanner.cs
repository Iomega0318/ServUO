/*
 * Created by GreyWolf
 * Date: 10/11/2007
 *  
 */
using System;

namespace Server.Items
{
    [Flipable(0x15C0, 0x15C1)]
    public class AtlantisBanner : Item, IDyable
    {
        [Constructable]
        public AtlantisBanner()
            : base(0x15C0)
        {
            Name = "I Found The Lost City Of Atlantis!";
            Weight = 2.0;
			Hue = 2995;
        }

        public AtlantisBanner(Serial serial)
            : base(serial)
        {
        }
        public bool Dye(Mobile from, DyeTub sender)
        {
            if (Deleted)
            {
                return false;
            }

            Hue = sender.DyedHue;

            return true;
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