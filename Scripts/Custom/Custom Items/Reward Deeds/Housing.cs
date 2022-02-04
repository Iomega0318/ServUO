//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/10/2021 2:42:03 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class HouseStarsDeed : Item
	{
		[Constructable]
		public HouseStarsDeed() : base(0x14F0)
		{
			Name = "House in the Stars";
			Weight = 1.00;
			//Hue = 1;
		}

		public HouseStarsDeed( Serial serial ) : base( serial )
		{
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            {
                list.Add("<BASEFONT COLOR=#7CFC00>Use: Page Staff to Redeem</BASEFONT>");
                //{ "Use: Page Staff to Redeem".WrapUOHtmlColor(Color.LawnGreen)};
            }
        }

        public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

	}

    public class HouseIslandDeed : Item
    {
        [Constructable]
        public HouseIslandDeed() : base(0x14F0)
        {
            Name = "Private Island House";
            Weight = 1.00;
            //Hue = 1;
        }

        public HouseIslandDeed(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            {
                list.Add("<BASEFONT COLOR=#7CFC00>Use: Page Staff to Redeem</BASEFONT>");
                //{ "Use: Page Staff to Redeem".WrapUOHtmlColor(Color.LawnGreen)};
            }
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

    public class CustomHouseDeed : Item
    {
        [Constructable]
        public CustomHouseDeed() : base(0x14F0)
        {
            Name = "Custom House Built by Staff";
            Weight = 1.00;
            //Hue = 1;
        }

        public CustomHouseDeed(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            {
                list.Add("<BASEFONT COLOR=#7CFC00>Use: Page Staff to Redeem</BASEFONT>");
                //{ "Use: Page Staff to Redeem".WrapUOHtmlColor(Color.LawnGreen)};
            }
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

    public class CustomGuildHouseDeed : Item
    {
        [Constructable]
        public CustomGuildHouseDeed() : base(0x14F0)
        {
            Name = "Custom Guild House";
            Weight = 1.00;
            //Hue = 1;
        }

        public CustomGuildHouseDeed(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
            {
                list.Add("<BASEFONT COLOR=#7CFC00>Use: Page Staff to Redeem</BASEFONT>");
                //{ "Use: Page Staff to Redeem".WrapUOHtmlColor(Color.LawnGreen)};
            }
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
