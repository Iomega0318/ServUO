//=================================================
//This script was created by Gizmo's Uo Quest Maker
//This script was created on 11/9/2021 9:56:24 PM
//=================================================
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections;
using System.Collections.Generic;

namespace Server.Engines.Quests
{
	public class Name : MondainQuester
	{
		public override bool DisallowAllMoves { get { return true; } }

		public override Type[] Quests
		{
			get
			{
				return new Type[]
		   {
				typeof( ThePerfectCut )
		   };
			}
		}

		[Constructable]
		public Name() : base("Name", "Title")
		{
			InitBody();
		}
		public Name(Serial serial) : base(serial)
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

		public override void InitBody()
		{
			InitStats(100, 100, 100);
			Female = Utility.RandomList(true, false);
			Race = Utility.RandomList(Race.Human, Race.Elf);
			base.InitBody();
		}
		public override void InitOutfit()
		{
			//AddItem(new Shirt(Utility.RandomNeutralHue();) );
			//AddItem(new LongPants(Utility.RandomNeutralHue();) );
			//AddItem(new Boots(Utility.RandomNeutralHue();) );
			//AddItem(new WelcomeShroud(Utility.RandomNeutralHue();) );

            //BearMask head = new BearMask();
            //head.Hue = 347;
            //AddItem(head);
            Shirt chest = new Shirt();
            chest.Hue = Utility.RandomNeutralHue();
            AddItem(chest);
            LongPants leg = new LongPants();
            leg.Hue = Utility.RandomNeutralHue();
            AddItem(leg);
            Boots feet = new Boots();
            feet.Hue = Utility.RandomNeutralHue();
            AddItem(feet);

            AddItem(new WelcomeShroud() );
        }
	}
}
