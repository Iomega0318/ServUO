using System;
using Server;

namespace Server.Items
{
	public class ResonanceDefenderOfATA : BaseShield
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 65; } }

		public override int AosStrReq{ get{ return 90; } }

		public override int ArmorBase{ get{ return 23; } }

		[Constructable]
		public ResonanceDefenderOfATA() : base( 0x1B76 )
		{
	    
        Name = "Resonance Defender Of ATA";
        ItemID = 21536;

				    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

		Attributes.RegenHits = 25;
		Attributes.RegenStam = 10;
		Attributes.RegenMana = 5;
		Attributes.DefendChance = 20;
		Attributes.AttackChance = 20;
		Attributes.BonusStr = 5;
		Attributes.BonusDex = 5;
		Attributes.BonusInt = 5;
		Attributes.BonusHits = 5;
		Attributes.BonusStam = 5;
		Attributes.BonusMana =  5;

	    Attributes.ReflectPhysical = 15;


		AbsorptionAttributes.ResonanceFire = 10;		
		AbsorptionAttributes.ResonanceCold = 10;	
		AbsorptionAttributes.ResonancePoison = 10;		
		AbsorptionAttributes.ResonanceEnergy = 10;		
		AbsorptionAttributes.ResonanceKinetic = 10;	

			
			
            ArmorAttributes.SelfRepair = 50;

			PoisonBonus = 25;
		}

		public ResonanceDefenderOfATA( Serial serial ) : base(serial)
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );//version
		}
	}
}
