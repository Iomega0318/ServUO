using System;
using Server;

namespace Server.Items
{
	public class MaleGargoyleSoulArmsOfATA : LeatherArms
	{
		public override int LabelNumber{ get{ return 1061093; } } // Midnight Bracers
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
		public MaleGargoyleSoulArmsOfATA()
		{
			Hue = 1154;
			ItemID = 770;
			
			Name = "Male Gargoyle Soul Arms Of ATA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
            
            Attributes.Luck = 75;
            Attributes.NightSight = 25;

		ArmorAttributes.SoulCharge = 5;
		ArmorAttributes.MageArmor = 4;

	 	Attributes.RegenHits = 10;
	 	Attributes.RegenStam = 10;
		AbsorptionAttributes.SoulChargeFire = 15;		
		AbsorptionAttributes.SoulChargeCold	= 15;	
		AbsorptionAttributes.SoulChargePoison = 15;	
		AbsorptionAttributes.SoulChargeEnergy = 15;	
		AbsorptionAttributes.SoulChargeKinetic = 15;	
		
        AbsorptionAttributes.CastingFocus = 5;


			EnergyBonus = 10;
			
		}

		public MaleGargoyleSoulArmsOfATA( Serial serial ) : base( serial )
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
				PhysicalBonus = 0;
		}
	}
}