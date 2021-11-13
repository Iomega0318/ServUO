using System;
using Server;

namespace Server.Items
{
	public class PirateGorget : PlateGorget
	{
		public override int ArtifactRarity{ get{ return 30; } }

		public override int InitMinHits{ get{ return 1000; } }
		public override int InitMaxHits{ get{ return 1000; } }

		[Constructable]
		public PirateGorget()
		{
			Weight = 2.0; 
            		Name = "Pirate Gorget"; 
            		Hue = 2995;

			
			Attributes.BonusDex = 3;
			Attributes.BonusInt = 3;
			Attributes.BonusStr = 3;
			Attributes.CastRecovery = 3;
			Attributes.CastSpeed = 3;
			Attributes.DefendChance = 3;
			Attributes.LowerRegCost = 15;
			Attributes.ReflectPhysical = 10;
			Attributes.RegenHits = 5;
			Attributes.RegenMana = 5;
			

			ArmorAttributes.SelfRepair = 25;

			
			StrRequirement = 20;

			

		}

		public PirateGorget( Serial serial ) : base( serial )
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