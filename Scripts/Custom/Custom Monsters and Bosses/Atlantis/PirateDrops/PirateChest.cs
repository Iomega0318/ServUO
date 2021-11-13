using System;
using Server;

namespace Server.Items
{
	public class PirateChest : PlateChest
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public PirateChest()
		{
			Weight = 3.0; 
            		Name = "Pirate Chest"; 
            		Hue = 2995;

			Attributes.AttackChance = 10;
			
			Attributes.BonusInt = 10;

			Attributes.DefendChance = 25;
			Attributes.LowerRegCost = 35;
			Attributes.Luck = 25;
			Attributes.ReflectPhysical = 25;
			Attributes.RegenHits = 5;
			


			
			
			ArmorAttributes.SelfRepair = 25;

			ColdBonus = 15;
			EnergyBonus = 15;
			FireBonus = 15;
			PoisonBonus = 15;
			StrRequirement = 20;

			

		}

		public PirateChest( Serial serial ) : base( serial )
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