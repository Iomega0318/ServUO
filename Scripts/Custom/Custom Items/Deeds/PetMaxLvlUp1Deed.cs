using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
    public class MaxLvlUp1Target : Target
    {
        private MaxLvlUp1Deed m_Deed;
        private Mobile m_from;
        private int MaxLvlAdjust;

        public MaxLvlUp1Target(MaxLvlUp1Deed deed) : base(1, false, TargetFlags.None)
        {
            m_Deed = deed;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (m_Deed.Deleted)
                return;

            if (target is BaseCreature)
            {
                BaseCreature mobile = (BaseCreature)target;
                int MaxLvlAdjust = mobile.MaxLevel;

                if (MaxLvlAdjust >= 50)
                {
                    from.SendMessage(0x35, "The pets level is already maxed out.");
                }
                else
                {
                    MaxLvlAdjust = MaxLvlAdjust + 1;

                    if (MaxLvlAdjust > 50)
                    {
                        MaxLvlAdjust = 50;
                        mobile.MaxLevel = MaxLvlAdjust;
                        from.SendMessage(0x35, "The pets has reached it's max, Max Level 50 obtained.");
                        m_Deed.Delete();
                    }
                    else
                    {
                        mobile.MaxLevel = MaxLvlAdjust;
                        from.SendMessage(0x35, "The pet max level has been raised by 1.");
                        m_Deed.Delete();
                    }
                }


            }
            else
            {
                from.SendMessage(0x35, "This deed only works on pets.");
            }
        }
    }

    public class MaxLvlUp1Deed : Item // Create the item class which is derived from the base item class
    {
        [Constructable]
        public MaxLvlUp1Deed() : base(0x14F0)
        {
            Weight = 1.0;
            Name = "a pet level up deed";
            LootType = LootType.Blessed;
            Hue = 1278;
        }

        public override bool DisplayLootType { get { return true; } }

        /*public override void OnDoubleClick( Mobile from )
		{
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage(0x35, "The Deed Must Be In Your Bag To Use It");
            }
            else
            {
                from.SendMessage(0x35, "Which pet do you wish to increase the Max Level of?");
                from.Target = new MaxLvlUp1Target(this);
            }
		}*/
        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else if (from.InRange(this.GetWorldLocation(), 1))
            {
                from.SendMessage("Which pet would you like to level up?");
                from.Target = new MaxLvlUp1Target(this);
            }
            else
            {
                from.SendLocalizedMessage(500446); // That is too far away. 
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("<BASEFONT COLOR=#7FCAE7>Raises max pet level by 1" + "<BASEFONT COLOR=#FFFFFF>");
        }

        public MaxLvlUp1Deed(Serial serial) : base(serial)
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
