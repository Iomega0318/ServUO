using System;
using Server;

namespace Server.Items
{
	public class ATARocksRobe : Robe
	{
		public override int LabelNumber{ get{ return 1094926; } } // Good Samaritan of Britannia [Replica]

		public override int ArtifactRarity{ get{ return 101; } }

		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		public override bool CanFortify{ get{ return true; } }

		[Constructable]
		public ATARocksRobe()
		{
			
         Name = "ATA Rocks!";
         Layer = Layer.OuterTorso;
         ItemID = 24853;
      

		Attributes.RegenHits = 5;
		Attributes.RegenStam = 5;
	
		Attributes.DefendChance = 10;
		Attributes.AttackChance = 10;
		Attributes.BonusStr = 10;
		Attributes.BonusDex = 10;
		Attributes.BonusInt = 10;
		Attributes.BonusHits = 10;
		Attributes.BonusStam = 15;
		
		Attributes.WeaponDamage = 5;
		Attributes.WeaponSpeed = 5;

		Attributes.ReflectPhysical = 15;
		Attributes.EnhancePotions = 15;
		Attributes.Luck = 15;
		
		Attributes.NightSight = 25;
		}

		public ATARocksRobe( Serial serial ) : base( serial )
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