/////////////////////////////////////////////////
//
// Automatically generated by the
// AddonGenerator script by Arya
//
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CouchNorthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CouchNorthAddonDeed();
			}
		}

		[ Constructable ]
		public CouchNorthAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 1801 );
			AddComponent( ac, -2, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 2, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 2, 0, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, -2, 0, 0 );
			ac = new AddonComponent( 1113 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 1113 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 1113 );
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 5690 );
			AddComponent( ac, 2, 1, 5 );
			ac = new AddonComponent( 5690 );
			AddComponent( ac, -2, 1, 5 );
			ac = new AddonComponent( 5029 );
			AddComponent( ac, -1, 1, 5 );
			ac = new AddonComponent( 5029 );
			AddComponent( ac, 0, 1, 5 );
			ac = new AddonComponent( 5029 );
			AddComponent( ac, 1, 1, 5 );
			ac = new AddonComponent( 5035 );
			AddComponent( ac, 2, 0, 5 );
			ac = new AddonComponent( 5035 );
			AddComponent( ac, -2, 0, 5 );

		}

		public CouchNorthAddon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class CouchNorthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CouchNorthAddon();
			}
		}

		[Constructable]
		public CouchNorthAddonDeed()
		{
			Name = "CouchNorth";
		}

		public CouchNorthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}