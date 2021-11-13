
//////////////////////
//Created by Malkhia//
//////////////////////

using System;
using Server;

namespace Server.Items
{
	public class ScaledLegsOfAtlantis : PlateLegs
	{

		public override int ArtifactRarity{ get{ return 80; } }

		public override int InitMinHits{ get{ return 600; } }
		public override int InitMaxHits{ get{ return 600; } }

		[Constructable]
		public ScaledLegsOfAtlantis()
		{
			Name = "Scaled Legs Of Atlantis";
                        Hue = 2823;
                        
						ArmorAttributes.SelfRepair = 30;
                        Attributes.RegenHits = 5;
                        Attributes.RegenMana = 5;
                        Attributes.LowerManaCost = 10;
                        Attributes.BonusInt = 10;
                        Attributes.Luck = 20;

			 ColdBonus = 8;
			 EnergyBonus = 8;
			 FireBonus = 8;
			 PhysicalBonus = 8;
			 PoisonBonus = 8;
		}

		public ScaledLegsOfAtlantis( Serial serial ) : base( serial )
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
