using System;
using Server;

namespace Server.Items
{
	public class HeaddressOfAtA : DeerMask
	{
		public override int LabelNumber{ get{ return 1061595; } } // Hunter's Headdress

		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 17; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public HeaddressOfAtA()
		{
			Hue = 1150;
			Name = "Headress Of AtA";



            Attributes.BonusDex = 10;
			Attributes.RegenHits = 2;
			Attributes.Luck = 10;
            Attributes.DefendChance = 10;
			Attributes.LowerRegCost = 2;
			Attributes.ReflectPhysical = 2;
			Attributes.DefendChance = 10;
			Attributes.BonusDex = 2;
	 	 	Attributes.BonusStam = 10;
	 	 	Attributes.RegenHits = 2;
	 	 	Attributes.RegenStam = 10;
	 	 	Attributes.RegenMana = 2;
	 	 	Attributes.AttackChance = 10;
	 	 	Attributes.DefendChance = 2;
	 	 	Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 2;
	        Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 2;
	 	 	

		}

		public HeaddressOfAtA( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					Resistances.Cold = 2;
					break;
				}
			}
		}
	}
}