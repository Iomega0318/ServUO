using System;
using Server;

namespace Server.Items
{
	public class AtlantisStatue : Item
	{
		public override int LabelNumber{ get{ return 1073195; } } // A Quagmire Contribution Statue from the Britannia Royal Zoo.
	
		[Constructable]
		public AtlantisStatue() : base( 4824 )
		{
			LootType = LootType.Regular;
			Weight = 15.0;
			Hue = 2995;
		}

		public AtlantisStatue( Serial serial ) : base( serial )
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

