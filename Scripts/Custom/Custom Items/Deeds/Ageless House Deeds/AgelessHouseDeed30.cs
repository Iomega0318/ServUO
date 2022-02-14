//Ageless House Deed For RunUO SVN
//By DxMonkey - AKA - Tresdni
//Ultima Eclipse - www.ultimaeclipse.com
using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server.Multis;

namespace Server.Items
{
    public class AgelessHouse30Target : Target
    {
        private AgelessHouse30Deed m_Deed;

        public AgelessHouse30Target(AgelessHouse30Deed deed) : base(1, false, TargetFlags.None)
        {
            m_Deed = deed;
        }

        protected override void OnTarget(Mobile from, object target)
        {
            if (m_Deed.Deleted || m_Deed.RootParent != from)
                return;

            if (target is HouseSign)
            {
                HouseSign item = (HouseSign)target;

                if (item.RestrictDecay == true)
                {
                    from.SendMessage("This house is already ageless");
                }

                else
                {
                    item.RestrictDecay = true;
                    from.SendMessage("The house is now ageless for 30 Days");

                    Timer m_timer = new AgelessHouse30Timer(item);
                    m_timer.Start();

                    m_Deed.Delete(); // Delete the ageless house deed
                }
            }
            else
            {
                from.SendMessage("You must target a house sign!");
            }
        }
    }

    public class AgelessHouse30Timer : Timer
    {
        private HouseSign sign;

        public AgelessHouse30Timer(HouseSign h) : base(TimeSpan.FromDays(30))
        {
            sign = h;
            Priority = TimerPriority.OneSecond;
        }
        protected override void OnTick()
        {

            sign.RestrictDecay = false;

        }
    }


    public class AgelessHouse30Deed : Item
    {

        [Constructable]
        public AgelessHouse30Deed() : base(0x14F0)
        {
            Weight = 1.0;
            Hue = 1159;
            LootType = LootType.Blessed;
            Name = "An Ageless House Deed ( 30 Days )";

        }

        public AgelessHouse30Deed(Serial serial) : base(serial)
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
            LootType = LootType.Blessed;

            int version = reader.ReadInt();
        }


        public override void OnDoubleClick(Mobile from) // Override double click of the deed to call our target
        {
            if (!IsChildOf(from.Backpack)) // Make sure its in their pack
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
            }
            else
            {
                from.SendMessage("Which house would you like to make ageless?");
                from.Target = new AgelessHouse30Target(this); // Call our target
            }
        }
    }
}
