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
	public class CoffinOpenTopAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new CoffinOpenTopAddonDeed();
			}
		}

		[ Constructable ]
		public CoffinOpenTopAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 7309 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 7308 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 7303 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 7310 );
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 7307 );
			AddComponent( ac, -2, 0, 0 );
			ac = new AddonComponent( 7306 );
			AddComponent( ac, -2, 1, 0 );
			ac = new AddonComponent( 7305 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 1313 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 7304 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 1313 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 7311 );
			AddComponent( ac, 2, 0, 0 );
			ac = new AddonComponent( 7302 );
			AddComponent( ac, 2, 1, 0 );

		}

		public CoffinOpenTopAddon( Serial serial ) : base( serial )
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

	public class CoffinOpenTopAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new CoffinOpenTopAddon();
			}
		}

		[Constructable]
		public CoffinOpenTopAddonDeed()
		{
			Name = "CoffinOpenTop";
		}

		public CoffinOpenTopAddonDeed( Serial serial ) : base( serial )
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