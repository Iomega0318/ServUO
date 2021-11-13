using System;

namespace Server.Items
{

public class AtlantisFloweringVine4 : Item
	{
		[Constructable]
		public AtlantisFloweringVine4() : base( 11515 )
		{
			Name = "Atlantis Flowering Vine";
			Weight = 1.0;
		}

		public AtlantisFloweringVine4( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
