using System;
using Server;

namespace Server.Items
{
	public class HelmOfAtA : PlateHelm
	{
		public override int LabelNumber{ get{ return 1061096; } } // Helm of Insight
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public HelmOfAtA()
		{
			Hue = 1150;
			Name = "Helm Of AtA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

            Attributes.BonusStr = 20;
			Attributes.BonusDex = 20;
			Attributes.Luck = 10;
			Attributes.LowerRegCost = 15;
			Attributes.ReflectPhysical = 10;
	 	 	Attributes.BonusStam = 25;
	 	 	Attributes.RegenHits = 4;
	 	 	Attributes.RegenStam = 10;
	 	 	Attributes.RegenMana = 4;
	 	 	Attributes.AttackChance = 10;
	 	 	Attributes.DefendChance = 40;
	 	 	Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 12;
	        Attributes.CastSpeed = 4;
	 	 	Attributes.CastRecovery = 4;
	 	 	Attributes.SpellDamage = 25;
			ArmorAttributes.MageArmor = 10;
			ArmorAttributes.SelfRepair = 50;
	 	 	PoisonBonus = 10;
		}

		public HelmOfAtA( Serial serial ) : base( serial )
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
				EnergyBonus = 17;
		}
	}
}