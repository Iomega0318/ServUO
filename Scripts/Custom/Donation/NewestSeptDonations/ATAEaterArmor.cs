using System;
using Server;

namespace Server.Items
{
	public class ATAEaterArmor : LeatherChest
	{
		public override int LabelNumber{ get{ return 1061098; } } // Armor of Fortune
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ATAEaterArmor()
		{
			Name = "I EAT You!";
            ItemID = 21689;

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			

            Attributes.Luck = 75;
            Attributes.NightSight = 25;
            Attributes.BonusStr = 15;

            Attributes.ReflectPhysical = 25;
            Attributes.DefendChance = 25;
            Attributes.AttackChance = 15;
            Attributes.EnhancePotions = 25;

	 	 	Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 5;

	 	 	Attributes.BonusStam = 10;
	 	 	Attributes.RegenHits = 10;
	 	 	Attributes.RegenStam = 10;

		AbsorptionAttributes.EaterCold = 10;			
		AbsorptionAttributes.EaterPoison = 10;			
		AbsorptionAttributes.EaterEnergy = 10;			
		AbsorptionAttributes.EaterKinetic = 10;		
		AbsorptionAttributes.EaterDamage = 10;

		    ArmorAttributes.LowerStatReq = 10;
		    ArmorAttributes.DurabilityBonus = 15;
		    ArmorAttributes.ReactiveParalyze =10;

		    
		    ArmorAttributes.SelfRepair = 50;

	    }    



		public ATAEaterArmor ( Serial serial ) : base( serial )
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