using System;
using Server;

namespace Server.Items
{
	public class ScaledMaleLegsOfAtA : ChainLegs
	{
		public override int LabelNumber{ get{ return 1061598; } } // Shadow Dancer Leggings
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ScaledMaleLegsOfAtA()
		{
			ItemID = 21401;
			Hue = 0;
			
			Name = "Scaled Male Legs Of AtA";


		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			
			Attributes.RegenHits = 18;

            Attributes.ReflectPhysical = 10;
			Attributes.DefendChance = 8;
			
			Attributes.BonusDex = 10;
	 	 	Attributes.BonusStam = 10;
	 	 	
			Attributes.RegenHits = 18;
	 	 	Attributes.RegenMana = 10;
	 	 	
			Attributes.AttackChance = 8;
	 	 	Attributes.DefendChance = 10;
	 	 	Attributes.WeaponDamage = 10;

			Attributes.Luck = 18;
	 	 	Attributes.WeaponSpeed = 8;
	 	 	Attributes.DefendChance = 10;
			Attributes.LowerRegCost = 10;
			
			ArmorAttributes.MageArmor = 2;
			Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 2;
	 	 	
			ArmorAttributes.SelfRepair = 50;
			
			FireBonus = 10;

			

		}

		public ScaledMaleLegsOfAtA( Serial serial ) : base( serial )
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

			if ( version < 1 )
			{
				if ( ItemID == 0x13CB )
					ItemID = 0x13BE;

				PhysicalBonus = 1;

			}
		}
	}
}