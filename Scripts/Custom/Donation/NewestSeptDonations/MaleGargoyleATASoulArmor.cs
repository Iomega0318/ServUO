using System;
using Server;

namespace Server.Items
{
	public class MaleGargoyleATASoulArmor : LeatherChest
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


		public override ArmorMeditationAllowance DefMedAllowance{ get{ return ArmorMeditationAllowance.All; } }

		public override Race RequiredRace{ get { return Race.Gargoyle; } }
		public override bool CanBeWornByGargoyles{ get{ return true; } }

		[Constructable]
		public MaleGargoyleATASoulArmor()
		{
			Name = "Male Gargoyle ATA Soul Armor";
            ItemID = 772;
            Hue = 1154;
			
		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

            Attributes.Luck = 75;
            Attributes.NightSight = 25;
            Attributes.BonusInt = 15;
	 	 	Attributes.BonusStam = 10;

            Attributes.ReflectPhysical = 25;
            Attributes.DefendChance = 25;
            Attributes.AttackChance = 15;
            Attributes.EnhancePotions = 25;

		ArmorAttributes.SoulCharge = 5;
		ArmorAttributes.MageArmor = 4;

	 	 	Attributes.RegenHits = 10;
	 	 	Attributes.RegenStam = 10;
		AbsorptionAttributes.SoulChargeFire = 10;		
		AbsorptionAttributes.SoulChargeCold	= 10;	
		AbsorptionAttributes.SoulChargePoison = 10;	
		AbsorptionAttributes.SoulChargeEnergy = 10;	
		AbsorptionAttributes.SoulChargeKinetic = 10;	
		
        AbsorptionAttributes.CastingFocus = 5;

		    
		    ArmorAttributes.SelfRepair = 50;

	    }    



		public MaleGargoyleATASoulArmor ( Serial serial ) : base( serial )
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