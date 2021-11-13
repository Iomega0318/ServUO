using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Accounting;
namespace Server.Items
{
    public class CharIncreaseScroll : Item
    {
        [Constructable]
        public CharIncreaseScroll() : base(0x14F0)
        {
            base.Weight = 1.0;
            base.Name = "a character slot deed";
        }

        public CharIncreaseScroll(Serial serial) : base(serial)
        {
        }

        public void Use(Mobile from)
        {
            //Account acct = from.Account as Account;
            //int chars = Convert.ToInt32(acct.GetTag("maxChars"));

            if (Deleted)
                return;

            if (IsChildOf(from.Backpack))
            {
                var acct = (Account)from.Account;
                var chars = Utility.ToInt32(acct.GetTag("maxChars"));

                if (chars < 7)
                {
                    from.SendLocalizedMessage(1049512); // You feel a surge of magic as the scroll enhances your powers!

                    acct.SetTag("maxChars", (chars + 1).ToString());

                    from.PlaySound(0x1EA);
                    from.FixedEffect(0x373A, 10, 15);

                    Delete();
                }
                else
                {
                    from.SendMessage("Your character slots are too high for this scroll.");
                }
            }
            else
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            Use(from);
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


