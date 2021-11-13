using System;
using Server;

namespace Server.Items
{
	public class AtAEaterHelm : PlateHelm
	{
		public override int LabelNumber{ get{ return 1061096; } } // Helm of Insight
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }


		[Constructable]
		public AtAEaterHelm()
		{

			Name = "Chomp";
            ItemID = 21693;

		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

            Attributes.Luck = 75;

            Attributes.BonusHits = 10;
            Attributes.BonusStam = 10;
	 	 	Attributes.RegenStam = 10;
	 	 	Attributes.RegenHits = 10;
            Attributes.ReflectPhysical = 10;
            Attributes.DefendChance = 10;
            Attributes.AttackChance = 10;
 
        AbsorptionAttributes.EaterCold = 10;			
		AbsorptionAttributes.EaterPoison = 10;			
		AbsorptionAttributes.EaterEnergy = 10;			
		AbsorptionAttributes.EaterKinetic = 10;		
		AbsorptionAttributes.EaterDamage = 10;

		    ArmorAttributes.LowerStatReq = 10;
		    ArmorAttributes.DurabilityBonus = 15;
		    ArmorAttributes.SelfRepair = 50;

	      }
		

		public AtAEaterHelm ( Serial serial ) : base( serial )
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