using System;
using Server;

namespace Server.Items
{
	public class PirateLegs : PlateLegs
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public PirateLegs()
		{
			Weight = 3.0; 
            		Name = "Pirate Leggings"; 
            		Hue = 2955;

			
			Attributes.BonusStam = 5;
			Attributes.DefendChance = 5;
			Attributes.LowerRegCost = 15;
			Attributes.ReflectPhysical = 5;
			Attributes.RegenStam = 2;
			Attributes.SpellChanneling = 1;
			Attributes.WeaponDamage = 18;
			Attributes.WeaponSpeed = 15;

			
			ArmorAttributes.MageArmor = 2;
			ArmorAttributes.SelfRepair = 25;

			
			PoisonBonus = 20;
			StrRequirement = 20;

			

		}

		public PirateLegs( Serial serial ) : base( serial )
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