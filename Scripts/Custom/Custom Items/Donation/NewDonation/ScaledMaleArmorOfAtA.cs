using System;
using Server;

namespace Server.Items
{
	public class ScaledMaleArmorOfAtA : LeatherChest
	{
		public override int LabelNumber{ get{ return 1061098; } } // Armor of Fortune
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ScaledMaleArmorOfAtA()
		{
			Name = "Scaled Male Armor Of AtA";
			Hue = 0;
		    ItemID = 21403;

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			
            Attributes.DefendChance = 20;
			Attributes.LowerRegCost = 35;
			ArmorAttributes.MageArmor = 4;
			
		    Attributes.Luck = 20;
			Attributes.ReflectPhysical = 25;
			Attributes.DefendChance = 15;
			
			Attributes.BonusDex = 10;
	 	 	Attributes.BonusStam = 10;
	 	 	
			Attributes.RegenHits = 10;
	 	 	Attributes.RegenStam = 5;
	 	 	Attributes.RegenMana = 10;
	 	 	
			Attributes.AttackChance = 5;
	 	 	Attributes.DefendChance = 10;
	 	 	
			Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 3;
	 	 	
			Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 2;

			ArmorAttributes.SelfRepair = 50;
	 	 	
			ColdBonus = 10;

			
	 	}


		public ScaledMaleArmorOfAtA ( Serial serial ) : base( serial )
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