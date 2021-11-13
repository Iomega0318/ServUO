
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class ArmsOfAtlantis : BoneArms
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public ArmsOfAtlantis()
		{
			Name = "Arms Of Atlantis";
                        Hue = 2823;
                        ArmorAttributes.SelfRepair = 30;
                        Attributes.DefendChance = 10;
                        Attributes.Luck = 25;
                        Attributes.SpellDamage = 15;
                        Attributes.RegenHits = 5;
                        Attributes.BonusHits = 5;
                        Attributes.LowerManaCost = 5;
                        Attributes.BonusInt = 10;
                       
			PhysicalBonus = 15;

		}

		public ArmsOfAtlantis( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
