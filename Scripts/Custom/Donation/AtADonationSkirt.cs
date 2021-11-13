using System;
using Server;

namespace Server.Items
{
	public class AtaDonationSkirt : PlateChest 
	{
		public override int ArtifactRarity{ get{ return 255; } }

		public override int InitMinHits{ get{ return 5000; } }
		public override int InitMaxHits{ get{ return 5000; } }

		[Constructable]
		public AtaDonationSkirt()
		{
			Weight = 1.0; 
            		Name = "AtA Donation Skirt"; 
            		Hue = 1153;
                        ItemID = 10138;                        
                        Layer = Layer.OuterLegs;

			  Attributes.AttackChance = 40;
		          Attributes.BonusStr = 25;
			  Attributes.DefendChance = 40;
			  Attributes.ReflectPhysical = 35;
			  Attributes.RegenHits = 13;
			  Attributes.RegenStam = 13;
			  Attributes.WeaponDamage = 45;
			  Attributes.WeaponSpeed = 35;
                          ArmorAttributes.SelfRepair = 30;

			  ColdBonus = 35;
			  EnergyBonus = 35;
			  FireBonus = 35;
			  PhysicalBonus = 35;
			  PoisonBonus = 35;
			  StrRequirement = 10;


		}

		public AtaDonationSkirt( Serial serial ) : base( serial )
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