using System;
using Server;

namespace Server.Items
{
	public class SkywardReachProtectionShield : HeaterShield
	{
		public override int ArtifactRarity{ get{ return 81; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public SkywardReachProtectionShield()
		{
			Weight = 6.0; 
            		Name = "Skyward Reach Protection Shield"; 
            		Hue = 0;
					ItemID = 21491;

			
			  Attributes.BonusStr = 10;
			  Attributes.DefendChance = 35;
			  Attributes.LowerRegCost = 15;
			  Attributes.ReflectPhysical = 15;

						
			  Attributes.DefendChance = 22;
						 
			  Attributes.RegenHits = 5;

			  Attributes.SpellChanneling = 1;
			 
			  ArmorAttributes.SelfRepair = 20;


			   ColdBonus = 11;
			   EnergyBonus = 11;

			   StrRequirement = 50;

			

		}
                                public override bool OnEquip( Mobile from )
                          {
	               from.FixedParticles( 0x375A, 1, 17, 9919, 33, 7, EffectLayer.Waist );
	               from.FixedParticles( 0x3728, 1, 13, 9502, 33, 7, (EffectLayer)255 );
                               from.PlaySound( 143 );
	               return base.OnEquip(from);
		}
		
                                public SkywardReachProtectionShield( Serial serial ) : base( serial )
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