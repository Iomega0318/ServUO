using System;
using Server;

namespace Server.Items
{
	public class AtlantisTreasure : GoldEarrings
	{
		public override int ArtifactRarity{ get{ return 80; } }
		
		[Constructable]
		public AtlantisTreasure()
		{
			
			Weight = 1.0; 
            Name = "Atlantis Treasure"; 
            Hue = 1268;

			Attributes.BonusInt = 2;
			Attributes.CastRecovery = 5;
			Attributes.CastSpeed = 2;
			Attributes.LowerManaCost = 5;
			Attributes.LowerRegCost = 2;
			Attributes.SpellDamage = 5;
			Resistances.Cold = 25;
			Resistances.Energy = 25;
			
		}

		public AtlantisTreasure ( Serial serial ) : base( serial )
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
