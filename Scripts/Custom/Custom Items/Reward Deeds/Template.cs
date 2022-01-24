//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/10/2021 2:42:03 PM
//=================================================

using System;
using Server;

namespace Server.Items
{
	public class TemplateDeed : Item
	{
		[Constructable]
		public TemplateDeed() : base(0x14F0)
		{
			Name = "Template";
			Weight = 1.00;
			//Hue = 1;
		}

		public TemplateDeed( Serial serial ) : base( serial )
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
}
