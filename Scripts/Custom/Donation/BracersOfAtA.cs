using System;
using Server;

namespace Server.Items
{
	public class BracersOfAtA : LeatherArms
	{
		public override int LabelNumber{ get{ return 1061093; } } // Midnight Bracers
		public override int ArtifactRarity{ get{ return 100; } }

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 17; } }
		public override int BaseColdResistance{ get{ return 17; } }
		public override int BasePoisonResistance{ get{ return 17; } }
		public override int BaseEnergyResistance{ get{ return 17; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public BracersOfAtA()
		{
			Hue = 1150;
			
			Name = "Bracers Of AtA";


            Attributes.BonusDex = 20;
            Attributes.BonusStr = 10;
            Attributes.BonusInt = 20;
			Attributes.Luck = 20;
			Attributes.LowerRegCost = 10;
            Attributes.LowerManaCost = 25;
			Attributes.ReflectPhysical = 45;
			Attributes.DefendChance = 45;
            Attributes.RegenHits = 12;
	 	 	Attributes.RegenStam = 15;
	 	 	Attributes.RegenMana = 10;
	 	 	Attributes.AttackChance = 25;
	 	 	Attributes.WeaponDamage = 25;
	 	 	Attributes.WeaponSpeed = 25;
	 	 	ArmorAttributes.SelfRepair = 50;
	 	 	Attributes.CastSpeed = 8;
	 	 	Attributes.CastRecovery = 8;
	 	 	Attributes.SpellDamage = 15;
	 	 	ArmorAttributes.SelfRepair = 50;
			ArmorAttributes.MageArmor = 2;
			
		}

		public BracersOfAtA( Serial serial ) : base( serial )
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