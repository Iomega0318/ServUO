using System;
using Server;

namespace Server.Items
{
	public class ArmorOfAtA : LeatherChest
	{
		public override int LabelNumber{ get{ return 1061098; } } // Armor of Fortune
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ArmorOfAtA()
		{
			Name = "Armor Of AtA";
			Hue = 1150;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;
			
            Attributes.DefendChance = 45;
			Attributes.LowerRegCost = 35;
			ArmorAttributes.MageArmor = 4;
			ArmorAttributes.SelfRepair = 5;
		    Attributes.Luck = 75;
			Attributes.ReflectPhysical = 25;
			Attributes.BonusDex = 20;
            Attributes.BonusHits = 30;
	 	 	Attributes.BonusStam = 25;
	 	 	Attributes.RegenHits = 15;
	 	 	Attributes.RegenStam = 15;
	 	 	Attributes.RegenMana = 20;
	 	 	Attributes.AttackChance = 30;
	 	 	Attributes.WeaponDamage = 35;
	 	 	Attributes.WeaponSpeed = 25;
	 	 	ArmorAttributes.SelfRepair = 50;
	 	 	Attributes.CastSpeed = 9;
	 	 	Attributes.CastRecovery = 9;
	 	 	Attributes.SpellDamage = 25;
	 	 	PoisonBonus = 10;
	 	}


		public ArmorOfAtA ( Serial serial ) : base( serial )
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