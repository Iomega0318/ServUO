using System;
using Server;

namespace Server.Items
{
	public class HoodedCloakOfATA : PlateChest
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
		public HoodedCloakOfATA()
		{
			Weight = 1.1; 
            		Name = "Hooded Cloak Of ATA"; 
            		Hue = 0;
                        ItemID = 3987;
                        Layer = Layer.Cloak;

                        MeditationAllowance = ArmorMeditationAllowance.All;
                        Durability = ArmorDurabilityLevel.Indestructible;

			  Attributes.Luck = 25;
			  Attributes.DefendChance = 10;
			  Attributes.LowerRegCost = 25;
			  Attributes.BonusStr = 10;     
              Attributes.ReflectPhysical = 15;
              Attributes.RegenHits = 15;
              Attributes.AttackChance = 20;
              Attributes.NightSight = 25;

			Attributes.SpellChanneling = 2;
			Attributes.CastSpeed = 2;
	 	 	Attributes.CastRecovery = 2;
	 	 	Attributes.SpellDamage = 2;
			  
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

		public HoodedCloakOfATA( Serial serial ) : base( serial )
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