using System;
using Server;

namespace Server.Items
{
	public class LegsOfAtA : ChainLegs
	{
		public override int LabelNumber{ get{ return 1061598; } } // Shadow Dancer Leggings
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 25; } }
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 25; } }
		public override int BasePoisonResistance{ get{ return 25; } }
		public override int BaseEnergyResistance{ get{ return 25; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public LegsOfAtA()
		{
			ItemID = 0x13BE;
			Hue = 1150;
			
			Name = "Legs Of AtA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

			Attributes.BonusDex = 15;
			Attributes.RegenHits = 15;
			ArmorAttributes.SelfRepair = 50;
			Attributes.Luck = 75;
			Attributes.LowerRegCost = 65;
			ArmorAttributes.MageArmor = 2;
			ArmorAttributes.SelfRepair = 5;

            Attributes.BonusHits = 20;
            Attributes.BonusInt = 15;
            Attributes.BonusStr = 15;
			Attributes.ReflectPhysical = 20;
	 	 	Attributes.BonusStam = 25;
	 	 	Attributes.RegenHits = 7;
	 	 	Attributes.RegenStam = 7;
	 	 	Attributes.RegenMana = 10;
	 	 	Attributes.AttackChance = 20;
	 	 	Attributes.DefendChance = 25;
	 	 	Attributes.WeaponDamage = 20;
	 	 	Attributes.WeaponSpeed = 2;
	 	 	Attributes.CastSpeed = 5;
	 	 	Attributes.CastRecovery = 6;
	 	 	Attributes.SpellDamage = 20;
	 	 	FireBonus = 10;

		}

		public LegsOfAtA( Serial serial ) : base( serial )
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
				PoisonBonus = 1;
				EnergyBonus = 1;
			}
		}
	}
}