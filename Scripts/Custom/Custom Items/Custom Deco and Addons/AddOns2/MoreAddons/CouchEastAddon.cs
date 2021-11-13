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
	public class CouchEastAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CouchEastAddonDeed();
			}
		}

		[ Constructable ]
		public CouchEastAddon()
		{
			AddComponent( new AddonComponent( 1801 ), 0, 0, 0 );
			AddComponent( new AddonComponent( 5028 ), 0, 0, 5 );
			AddComponent( new AddonComponent( 1801 ), 0, 1, 0 );
			AddComponent( new AddonComponent( 5028 ), 0, 1, 5 );
			AddComponent( new AddonComponent( 1114 ), 1, 1, 0 );
			AddComponent( new AddonComponent( 1114 ), 1, 0, 0 );
			AddComponent( new AddonComponent( 1801 ), 1, 2, 0 );
			AddComponent( new AddonComponent( 5035 ), 1, 2, 5 );
			AddComponent( new AddonComponent( 1801 ), 0, 2, 0 );
			AddComponent( new AddonComponent( 5690 ), 0, 2, 5 );
			AddComponent( new AddonComponent( 1114 ), 1, -1, 0 );
			AddComponent( new AddonComponent( 1801 ), 1, -2, 0 );
			AddComponent( new AddonComponent( 5035 ), 1, -2, 5 );
			AddComponent( new AddonComponent( 1801 ), 0, -2, 0 );
			AddComponent( new AddonComponent( 5690 ), 0, -2, 5 );
			AddComponent( new AddonComponent( 1801 ), 0, -1, 0 );
			AddComponent( new AddonComponent( 5028 ), 0, -1, 5 );
			AddonComponent ac = null;
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 1801 );
			AddComponent( ac, 0, -2, 0 );
			ac = new AddonComponent( 5690 );
			AddComponent( ac, 0, -2, 5 );
			ac = new AddonComponent( 5028 );
			AddComponent( ac, 0, 1, 5 );
			ac = new AddonComponent( 5028 );
			AddComponent( ac, 0, 0, 5 );
			ac = new AddonComponent( 5028 );
			AddComponent( ac, 0, -1, 5 );

		}

		public CouchEastAddon( Serial serial ) : base( serial )
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

	public class CouchEastAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CouchEastAddon();
			}
		}

		[Constructable]
		public CouchEastAddonDeed()
		{
			Name = "CouchEast";
		}

		public CouchEastAddonDeed( Serial serial ) : base( serial )
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