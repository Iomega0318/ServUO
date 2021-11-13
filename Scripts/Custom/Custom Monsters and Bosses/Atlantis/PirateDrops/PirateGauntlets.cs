using System;
using Server;

namespace Server.Items
{
	public class PirateGauntlets : PlateGloves
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public PirateGauntlets()
		{
			Weight = 3.0; 
            		Name = "Pirate Gauntlets"; 
            		Hue = 2995;

			Attributes.BonusDex = 10;
			
			Attributes.DefendChance = 10;
			Attributes.LowerManaCost = 20;
			Attributes.ReflectPhysical = 25;
			Attributes.SpellDamage = 25;
			Attributes.WeaponDamage = 5;
			

			ArmorAttributes.SelfRepair = 10;

			ColdBonus = 20;
			EnergyBonus = 20;
			
		
			StrRequirement = 20;

			

		}

		public PirateGauntlets( Serial serial ) : base( serial )
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