using System;
using Server;

namespace Server.Items
{
	public class SkywardReachSquallPendant : GoldNecklace
	{
		
		public override int ArtifactRarity{ get{ return 81; } }

		[Constructable]
		public SkywardReachSquallPendant()
		{
			Weight = 2.0; 
            Name = "Skyward Reach Squall Pendant"; 
            Hue = 0;
			ItemID = 21700;
			
			Attributes.BonusInt = 8;
			Attributes.BonusDex = 8;
			
			Attributes.LowerRegCost = 8;
            Attributes.DefendChance = 8;
			
			Attributes.RegenHits = 8;
			Attributes.RegenStam = 8;
			
			Resistances.Energy = 8;
			Resistances.Cold = 8;
			
		    Attributes.CastRecovery = 4;
			Attributes.CastSpeed = 4;
			Attributes.SpellDamage = 4;
		}

		public SkywardReachSquallPendant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
