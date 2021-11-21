using System;
using Server;

namespace Server.Items
{
	public class JewlsOfATA : GoldEarrings
	{
		public override int ArtifactRarity{ get{ return 100; } }
		
		[Constructable]
		public JewlsOfATA()
		{
			
			Weight = 1.0; 
            Name = "Jewels O ATA"; 
            Hue = 1154;
            Attributes.BonusStr = 10;
            Attributes.BonusDex = 10;
			Attributes.BonusInt = 10;
			Attributes.Luck = 25;
			Attributes.CastRecovery = 7;
			Attributes.CastSpeed = 7;
			Attributes.LowerManaCost = 25;
			Attributes.LowerRegCost = 25;
			Attributes.SpellDamage = 20;
			Resistances.Cold = 5;
			Resistances.Energy = 5;
			Resistances.Fire = 5;
						Attributes.LowerRegCost = 20;
		}

		public JewlsOfATA ( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
