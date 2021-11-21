using System;
using Server;

namespace Server.Items
{
	public class ATAEaterLegs : ChainLegs
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


		[Constructable]
		public ATAEaterLegs()
		{
			ItemID = 21690;
            Name = "You Look Like Dinner";

					    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;


            Attributes.ReflectPhysical = 15;
            Attributes.DefendChance = 15;
            Attributes.AttackChance = 10;

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
	 	 	FireBonus = 5;
            EnergyBonus = 5;


      }

		
		public ATAEaterLegs( Serial serial ) : base( serial )
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