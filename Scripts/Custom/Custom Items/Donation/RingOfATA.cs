using System;
using Server;

namespace Server.Items
{
	public class RingOfATA : GoldRing
	{
		
		 public override int ArtifactRarity{ get{ return 50; } }

		[Constructable]
		public RingOfATA()
		{
			Weight = 1.0;
			Name = "Ring Of ATA";
			Hue = 1150;

			 
			  Attributes.BonusDex = 10;
			  Attributes.BonusInt = 10;
			  Attributes.BonusStr = 10;
			  Attributes.CastRecovery = 4;
			  Attributes.CastSpeed = 4;
			  Attributes.LowerManaCost = 7;
			  Attributes.LowerRegCost = 35;
			  Attributes.Luck = 50;
			  Attributes.ReflectPhysical = 25;
			  Attributes.RegenHits = 10;
			  Attributes.RegenMana = 10;
			  
              Resistances.Cold = 15;
			  Resistances.Energy = 15;
			  Resistances.Fire = 15;
			  Resistances.Physical = 25;
			  Resistances.Poison = 15;
			  Attributes.LowerRegCost = 20;

			
			
		}

		public RingOfATA( Serial serial ) : base( serial )
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