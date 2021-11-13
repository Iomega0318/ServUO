using System;

namespace Server.Items
{

public class AtlantisFloweringVine2 : Item
	{
		[Constructable]
		public AtlantisFloweringVine2() : base( 11513 )
		{
			Name = "Atlantis Flowering Vine";
			Weight = 1.0;
		}

		public AtlantisFloweringVine2( Serial serial ) : base( serial )
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
