using System;
using Server;

namespace Server.Items
{
	public class ScaledFemaleArmsOfAtA : LeatherArms
	{
		public override int LabelNumber{ get{ return 1061093; } } // Midnight Bracers
		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 20; } }
		public override int BaseColdResistance{ get{ return 20; } }
		public override int BasePoisonResistance{ get{ return 20; } }
		public override int BaseEnergyResistance{ get{ return 20; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public ScaledFemaleArmsOfAtA()
		{
			Hue = 0;
			ItemID = 21398;
			
			Name = "Scaled Female Arms Of AtA";

		    MeditationAllowance = ArmorMeditationAllowance.All;
            Durability = ArmorDurabilityLevel.Indestructible;
			
			Attributes.RegenHits = 8;
		
			Attributes.Luck = 15;
           
			Attributes.LowerRegCost = 10;
			Attributes.ReflectPhysical = 15;
		
            Attributes.RegenHits = 2;
	 	 	Attributes.RegenStam = 2;
	 	 	Attributes.RegenMana = 10;
	 	 	
			Attributes.AttackChance = 15;
	 	 	Attributes.DefendChance = 15;
	 	 	
			Attributes.WeaponDamage = 10;
	 	 	Attributes.WeaponSpeed = 2;
	 	 	
	 	 	Attributes.CastSpeed = 4;
	 	 	Attributes.CastRecovery = 4;
	 	 	Attributes.SpellDamage = 4;
	 	 	
			ArmorAttributes.SelfRepair = 50;
			ArmorAttributes.MageArmor = 2;

			PoisonBonus = 10;

			
			
		}

		public ScaledFemaleArmsOfAtA( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if ( version < 1 )
				PhysicalBonus = 0;
		}
	}
}