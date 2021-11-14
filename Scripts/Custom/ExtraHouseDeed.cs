using System;
using Server.Accounting;
using Server.Targeting;

namespace Server.Items.Blah
{
    public class ExtraHouseDeed : Item
    {
        private int m_ExtraHousesToAdd = 1;

        [CommandProperty (AccessLevel.Counselor , AccessLevel.Administrator)]
        public int ExtraHousesToAdd
        {
            get { return m_ExtraHousesToAdd; }
            set {
                if (value < 1)
                    value = 1;

                m_ExtraHousesToAdd = value;
            }
        }

        [Constructable]
        public ExtraHouseDeed()
            : base (0x14F0)
        {
            Weight = 1.0;
            LootType = LootType.Blessed;
        }

        public ExtraHouseDeed(Serial serial)
            : base (serial)
        {
        }

        [Constructable]
        public ExtraHouseDeed(int extraHouses)
            : base()
        {
            ExtraHousesToAdd = extraHouses;
        }

        public override string DefaultName
        {
            get {
                return "an extra house deed";
            }
        }
        public override bool DisplayLootType
        {
            get {
                return Core.ML;
            }
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize (writer);

            writer.Write ((int)0); // version
            writer.Write ((int)ExtraHousesToAdd);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize (reader);

            int version = reader.ReadInt ();
            ExtraHousesToAdd = reader.ReadInt ();

            LootType = LootType.Blessed;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf (from.Backpack)) // Make sure its in their pack
            {
                from.SendLocalizedMessage (1042001); // That must be in your pack for you to use it.
            }
            else
            {
                if (from.Account is Account)
                {
                    Account account = from.Account as Account;
                    account.ExtraAccountHouses += ExtraHousesToAdd;

                    int totalAllowedHouses = Multis.BaseHouse.GetAccountHouseLimit (from);

                    from.SendMessage ("Your account may now have " + totalAllowedHouses.ToString () + " houses.");

                    Consume ();
                }
                else
                {
                    from.SendMessage ("You may not use this deed.");
                }
            }
        }
    }
}
