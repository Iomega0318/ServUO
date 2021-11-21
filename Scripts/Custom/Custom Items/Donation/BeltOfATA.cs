using System;
using Server;

namespace Server.Items
{
	public class BeltOfATA : PlateChest
	{
		public override int ArtifactRarity{ get{ return 100; } }

		
                public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }



                public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public BeltOfATA()
		{
			Weight = 5.1; 
            		Name = "Belt Of ATA"; 
            		Hue = 1154;
                        ItemID = 11112;
                        Layer = Layer.Waist;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;

			  
			  Attributes.DefendChance = 25;
			  Attributes.LowerRegCost = 25;
			  Attributes.BonusDex = 25;     
                          Attributes.ReflectPhysical = 25;
                          Attributes.RegenHits = 10;
                          Attributes.NightSight = 25;
			  ArmorAttributes.SelfRepair = 50;
                          Attributes.WeaponDamage = 20;
                          Attributes.BonusHits = 30;
			  Attributes.RegenMana = 10;

			  Attributes.SpellChanneling = 4;
			  Attributes.BonusMana = 15;


			  

			  

			  StrRequirement = 10;


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

		public BeltOfATA( Serial serial ) : base( serial )
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