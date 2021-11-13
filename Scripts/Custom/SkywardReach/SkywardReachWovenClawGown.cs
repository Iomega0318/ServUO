using System;
using Server;

namespace Server.Items
{
	public class SkywardReachWovenClawGown : PlateChest
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
		public SkywardReachWovenClawGown()
		{
			Weight = 5.1; 
            		Name = "SkywardReach Woven Claw Gown"; 
            		Hue = 0;
                        ItemID = 21696;
                        Layer = Layer.OuterTorso;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        

			   Attributes.BonusInt = 10;

		
			  Attributes.DefendChance = 15;
			  Attributes.AttackChance = 20;
			  
			  Attributes.LowerRegCost = 20;
			      
              Attributes.ReflectPhysical = 15;
              Attributes.RegenHits = 8;
			  
			  Attributes.NightSight = 25;
			  
			  ArmorAttributes.SelfRepair = 15;

			  ColdBonus = 10;
			  EnergyBonus = 10;
			  FireBonus = 10;
			  PhysicalBonus = 10;
			  PoisonBonus = 10;
                          
              StrRequirement = 20;


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

		public SkywardReachWovenClawGown( Serial serial ) : base( serial )
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