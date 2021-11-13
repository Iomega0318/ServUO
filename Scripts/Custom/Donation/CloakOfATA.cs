using System;
using Server;

namespace Server.Items
{
	public class CloakOfATA : PlateChest
	{
		public override int ArtifactRarity{ get{ return 101; } }

		
        public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }



        public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public CloakOfATA()
		{
			Weight = 1.1; 
            		Name = "Cloak Of ATA"; 
            		Hue = 0;
                        ItemID = 21599;
                        Layer = Layer.Cloak;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;

			  Attributes.Luck = 25;
			  Attributes.DefendChance = 20;
			  Attributes.LowerRegCost = 25;
			  Attributes.BonusStr = 15;
              Attributes.BonusDex = 15;
              Attributes.ReflectPhysical = 15;
              Attributes.RegenHits = 15;
              Attributes.AttackChance = 20;
              Attributes.NightSight = 25;

			Attributes.SpellChanneling = 2;
			Attributes.CastSpeed = 5;
	 	 	Attributes.CastRecovery = 4;
	 	 	Attributes.SpellDamage = 15;
			  
			  ArmorAttributes.SelfRepair = 50;
                          
                        
              StrRequirement = 10;

			PoisonBonus = 10;

			


		}
                        public override bool OnEquip( Mobile from )
                {
	                from.FixedParticles( 0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist );
                        from.FixedParticles( 0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist );
                        from.FixedParticles( 0x376A, 1, 62, 9923, 3, 3, EffectLayer.Waist );
                        from.FixedParticles( 0x3779, 1, 46, 9502, 5, 3, EffectLayer.Waist );
                        from.PlaySound( 535 );
	                from.PlaySound( 535 );
                        return base.OnEquip(from);
		}

		public CloakOfATA( Serial serial ) : base( serial )
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