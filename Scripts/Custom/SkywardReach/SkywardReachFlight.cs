using System;
using Server;

namespace Server.Items
{
	public class SkywardReachFlight : PlateChest
	{
		public override int ArtifactRarity{ get{ return 81; } }

		
                public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }



                public override int InitMinHits{ get{ return 2000; } }
		public override int InitMaxHits{ get{ return 2000; } }

		[Constructable]
		public SkywardReachFlight()
		{
			Weight = 1.1; 
            		Name = "Skyward Reach Flight"; 
            		Hue = 0;
                        ItemID = 21553;
                        Layer = Layer.Cloak;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;

			  Attributes.Luck = 25;
			  
			  Attributes.DefendChance = 10;
			  Attributes.LowerRegCost = 20;
			  
			  Attributes.BonusStr = 5; 
			  Attributes.BonusInt = 5;
			  Attributes.BonusDex = 5;
                          
						  Attributes.ReflectPhysical = 15;
                          Attributes.RegenHits = 12;
                          Attributes.AttackChance = 20;
                          
						  Attributes.NightSight = 25;
			  
			  ArmorAttributes.SelfRepair = 30;
                          
                        
                          StrRequirement = 30;


		}
                        public override bool OnEquip( Mobile from )
                {
	                from.FixedParticles( 0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist );
                        from.FixedParticles( 0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist );
                        from.FixedParticles( 0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist );
                        from.FixedParticles( 0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist );
                        from.PlaySound( 143 );
	                from.PlaySound( 144 );
                        return base.OnEquip(from);
		}

		public SkywardReachFlight( Serial serial ) : base( serial )
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