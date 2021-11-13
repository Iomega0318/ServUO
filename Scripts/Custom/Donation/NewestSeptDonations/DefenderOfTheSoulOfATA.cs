using System;
using Server;

namespace Server.Items
{
	public class DefenderOfTheSoulOfATA : BaseShield
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
		public DefenderOfTheSoulOfATA() : base( 0x1B76 )
		{
	    
        Name = "Defender Of The Soul Of ATA";
        ItemID = 21530;

         		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;

		Attributes.ReflectPhysical = 15;

         

			Attributes.DefendChance = 25;
			Attributes.BonusHits = 25;
		Attributes.ReflectPhysical = 15;
		ArmorAttributes.SoulCharge = 10;

		AbsorptionAttributes.SoulChargeFire = 10;		
		AbsorptionAttributes.SoulChargeCold	= 10;	
		AbsorptionAttributes.SoulChargePoison = 10;	
		AbsorptionAttributes.SoulChargeEnergy = 10;	
		AbsorptionAttributes.SoulChargeKinetic = 10;	
		AbsorptionAttributes.CastingFocus = 10;

         PhysicalBonus = 25;
           
          ArmorAttributes.SelfRepair = 50;
		}

		public DefenderOfTheSoulOfATA( Serial serial ) : base(serial)
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
