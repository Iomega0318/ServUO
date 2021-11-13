using System;

namespace Server.Items
{

public class AtlantisFloweringVine1 : Item
	{
		[Constructable]
		public AtlantisFloweringVine1() : base( 11516 )
		{
			Name = "Atlantis Flowering Vine";
			Weight = 1.0;
		}

		public AtlantisFloweringVine1( Serial serial ) : base( serial )
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
