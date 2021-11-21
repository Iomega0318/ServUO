using System;
using Server;

namespace Server.Items
{
	public class MaleATASoulArmor : LeatherChest
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
		public MaleATASoulArmor()
		{
			Name = "Male ATA Soul Armor";
            ItemID = 21441;

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			

            Attributes.Luck = 75;
            Attributes.NightSight = 25;
            Attributes.BonusInt = 15;


		ArmorAttributes.ReactiveParalyze = 5;

		Attributes.SpellDamage = 2;
		Attributes.CastRecovery = 2;
		Attributes.CastSpeed = 2;
		Attributes.LowerManaCost = 5;
		Attributes.LowerRegCost = 15;
		Attributes.RegenMana = 5;
		Attributes.BonusMana = 5;

            Attributes.ReflectPhysical = 25;;
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


		public MaleATASoulArmor ( Serial serial ) : base( serial )
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