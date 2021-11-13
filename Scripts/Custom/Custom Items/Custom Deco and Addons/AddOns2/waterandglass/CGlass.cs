using System;
using Server;

namespace Server.Items
{
	public class CGlass : Item
	{
		[Constructable]
		public CGlass() : this( null )
		{
		}

		[Constructable]
		public CGlass( string name ) : base( 7385 )
		{
			Name = "glass";
			Weight = 1.0;
			Movable = false;
			Hue = 2101;
		}

		public CGlass( Serial serial ) : base( serial )
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
