using System;
using Server;

namespace Server.Items
{
	public class CWater : Item
	{
		[Constructable]
		public CWater() : this( null )
		{
		}

		[Constructable]
		public CWater( string name ) : base( 7385 )
		{
			Name = "water";
			Weight = 1.0;
			Movable = false;
			Hue = 1266;
		}

		public CWater( Serial serial ) : base( serial )
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
