using System;
using Server;

namespace Server.Items
{
	public class MermaidsBelly : PlateChest
	{
		public override int ArtifactRarity{ get{ return 80; } }

		
                public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }



                public override int InitMinHits{ get{ return 2000; } }
		public override int InitMaxHits{ get{ return 2000; } }

		[Constructable]
		public MermaidsBelly()
		{
			Weight = 5.1; 
            		Name = "Mermaids Belly"; 
            		Hue = 2950;
                        ItemID = 11112;
                        Layer = Layer.Waist;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;

			  
			  Attributes.DefendChance = 10;
			  Attributes.LowerRegCost = 10;
			  Attributes.BonusDex = 8;     
                          Attributes.ReflectPhysical = 5;
                          Attributes.RegenHits = 5;
                          Attributes.NightSight = 25;
			  ArmorAttributes.SelfRepair = 30;
                          Attributes.WeaponDamage = 5;
                          Attributes.BonusHits = 10;
			  Attributes.RegenMana = 10;
			  

			  StrRequirement = 20;


		}
                        public override bool OnEquip( Mobile from )
                {
	                
	                from.FixedParticles( 0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist );
                        from.FixedParticles( 0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist );
                        from.FixedParticles( 0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist );
                        from.FixedParticles( 0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist );
                        from.PlaySound( 519 );
	                from.PlaySound( 1098 );
                        return base.OnEquip(from);
		}

		public MermaidsBelly( Serial serial ) : base( serial )
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