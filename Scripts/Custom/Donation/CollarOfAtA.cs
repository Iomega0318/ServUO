using System;
using Server;

namespace Server.Items
{
	public class CollarOfAtA : LeatherGorget
	{
		public override int LabelNumber{ get{ return 1061594; } } // Jackal's Collar
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 17; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public CollarOfAtA()
		{
			Hue = 1150;
			Name = "Collar Of AtA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

            Attributes.WeaponDamage = 15;
			Attributes.Luck = 40;
            Attributes.DefendChance = 20;
			Attributes.LowerRegCost = 5;
			ArmorAttributes.MageArmor = 5;
            Attributes.CastSpeed = 5;
            Attributes.CastRecovery = 5;
            Attributes.BonusInt = 15;
            Attributes.LowerManaCost = 15;
			Attributes.ReflectPhysical = 20;
			Attributes.BonusDex = 15;
	 	 	Attributes.BonusStam = 11;
            Attributes.BonusStr = 10;
            Attributes.WeaponSpeed = 15;
	 	 	Attributes.RegenHits = 15;
            Attributes.SpellDamage =15;
	 	 	Attributes.RegenStam = 10;
	 	 	Attributes.RegenMana = 10;

	 	 	ArmorAttributes.SelfRepair = 50;

	 	 	ColdBonus = 11;
		}

		public CollarOfAtA( Serial serial ) : base( serial )
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
				if ( Hue == 0x54B )
					Hue = 0x6D1;

				FireBonus = 17;
				ColdBonus = 17;
			}
		}
	}
}