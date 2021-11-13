//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/8/2021 9:46:35 PM
//=================================================
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engines.Quests
{
	public class Ochen : MondainQuester
	{
		public override Type[] Quests
		{
			get{ return new Type[]
			{
				typeof( ThePerfectCut ),
			};}
		}

		[Constructable]
		public Ochen() : base("Ochen", "The Tinker")
		{
			InitBody();
		}

		public Ochen(Serial serial) : base(serial)
		{
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

		public override void InitBody()
		{
			InitStats(100, 100, 100);
			Female = false;
			Race = Race.Human;
			base.InitBody();
		}
		public override void InitOutfit()
		{
			BearMask head = new BearMask();
			head.Hue = 347;
			AddItem( head );
			Tunic chest = new Tunic();
			chest.Hue = 347;
			AddItem( chest );
			LongPants leg = new LongPants();
			leg.Hue = 347;
			AddItem( leg );
			ThighBoots feet = new ThighBoots();
			feet.Hue = 347;
			AddItem( feet );
		}
	}
}
