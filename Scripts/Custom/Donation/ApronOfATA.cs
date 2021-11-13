using System;
using Server;

namespace Server.Items
{
	public class ApronOfATA : FullApron
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
		public ApronOfATA()
		{
			Weight = 1.1; 
            		Name = "Apron Of ATA"; 
            		Hue = 1154;
                        ItemID = 21677;
                        Layer = Layer.Waist;



			
			Attributes.AttackChance = 15;
			Attributes.BonusDex = 15;
			Attributes.BonusHits = 25;
			Attributes.BonusInt = 15;
			Attributes.BonusStr = 15;
			
			Attributes.DefendChance = 25;
			
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 10;
			Attributes.Luck = 50;
			
			Attributes.ReflectPhysical = 15;
			Attributes.RegenHits = 2;
			Attributes.RegenMana = 2;
			Attributes.RegenStam = 2;
			Attributes.SpellDamage = 10;
			Attributes.WeaponDamage = 15;
			
                        

			StrRequirement = 10;


		}
                        public override bool OnEquip( Mobile from )
                {
	                from.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
                        from.FixedParticles( 0x374A, 10, 15, 5021, EffectLayer.Waist );
                        from.PlaySound( 0x51A );
	                from.PlaySound( 0xFA );
                        from.PlaySound( 0xF5 );
                        return base.OnEquip(from);
		}

		public ApronOfATA( Serial serial ) : base( serial )
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