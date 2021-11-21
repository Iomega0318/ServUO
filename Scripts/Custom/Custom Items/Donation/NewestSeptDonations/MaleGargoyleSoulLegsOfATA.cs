using System;
using Server;

namespace Server.Items
{
	public class MaleGargoyleSoulLegsOfATA : ChainLegs
	{
		public override int LabelNumber{ get{ return 1061598; } } // Shadow Dancer Leggings
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
		public MaleGargoyleSoulLegsOfATA()
		{

			ItemID = 774;
            Hue = 1154;

			
			Name = "Male Gargoyle Soul Legs Of ATA";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;


		ArmorAttributes.SoulCharge = 5;
		ArmorAttributes.MageArmor = 4;

		ArmorAttributes.ReactiveParalyze = 5;

		Attributes.SpellDamage = 2;
		Attributes.CastRecovery = 2;
		Attributes.CastSpeed = 2;
		Attributes.LowerManaCost = 5;
		Attributes.LowerRegCost = 25;
		Attributes.RegenMana = 5;
		Attributes.BonusMana = 5;

		AbsorptionAttributes.SoulChargeFire = 10;		
		AbsorptionAttributes.SoulChargeCold = 10;		
		AbsorptionAttributes.SoulChargePoison = 10;	
		AbsorptionAttributes.SoulChargeEnergy = 10;	
		AbsorptionAttributes.SoulChargeKinetic = 10;	
		AbsorptionAttributes.CastingFocus = 5;

		    ArmorAttributes.LowerStatReq = 10;
		    ArmorAttributes.DurabilityBonus = 15;
		    ArmorAttributes.ReactiveParalyze =10;

		    
		    ArmorAttributes.SelfRepair = 50;

	 	 	FireBonus = 5;
            EnergyBonus = 5;

      }

		
		public MaleGargoyleSoulLegsOfATA( Serial serial ) : base( serial )
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