using System;
using Server;

namespace Server.Items
{
	public class PirateArms : PlateArms
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public PirateArms()
		{
			Weight = 3.0; 
            		Name = "Pirate Arms"; 
            		Hue = 2995;

			Attributes.AttackChance = 25;
			Attributes.BonusStr = 15;
			
			Attributes.Luck = 30;
			
			Attributes.RegenStam = 20;
			
			
			ArmorAttributes.SelfRepair = 25;

			
			StrRequirement = 20;

			

		}

		public PirateArms( Serial serial ) : base( serial )
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