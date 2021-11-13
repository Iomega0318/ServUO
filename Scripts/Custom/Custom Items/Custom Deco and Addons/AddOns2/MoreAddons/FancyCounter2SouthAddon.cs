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
	public class FancyCounter2SouthAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new FancyCounter2SouthAddonDeed();
			}
		}

		[ Constructable ]
		public FancyCounter2SouthAddon()
		{
			AddonComponent ac = null;
			ac = new AddonComponent( 6416 );
			AddComponent( ac, -2, -1, 0 );
			ac = new AddonComponent( 6428 );
			AddComponent( ac, -2, 0, 0 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, 0, 8 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, 0, 9 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, 0, 10 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, -1, 8 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, -1, 9 );
			ac = new AddonComponent( 2519 );
			AddComponent( ac, -2, -1, 10 );
			ac = new AddonComponent( 6430 );
			AddComponent( ac, 1, -1, 0 );
			ac = new AddonComponent( 6430 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 6430 );
			AddComponent( ac, -1, -1, 0 );
			ac = new AddonComponent( 6430 );
			AddComponent( ac, 2, -1, 0 );
			ac = new AddonComponent( 6417 );
			AddComponent( ac, 3, -1, 0 );
			ac = new AddonComponent( 6424 );
			AddComponent( ac, 3, 0, 0 );
			ac = new AddonComponent( 6419 );
			AddComponent( ac, 3, 1, 0 );
			ac = new AddonComponent( 2449 );
			AddComponent( ac, 3, 1, 10 );
			ac = new AddonComponent( 2449 );
			AddComponent( ac, 3, 0, 10 );
			ac = new AddonComponent( 2450 );
			AddComponent( ac, 2, -1, 9 );
			ac = new AddonComponent( 2450 );
			AddComponent( ac, 1, -1, 9 );
			ac = new AddonComponent( 6867 );
			AddComponent( ac, 3, 0, 11 );
			ac = new AddonComponent( 2886 );
			AddComponent( ac, 3, -1, 10 );
			ac = new AddonComponent( 6811 );
			AddComponent( ac, 3, -1, 15 );
			ac = new AddonComponent( 4155 );
			AddComponent( ac, 3, 1, 11 );

		}

		public FancyCounter2SouthAddon( Serial serial ) : base( serial )
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

	public class FancyCounter2SouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new FancyCounter2SouthAddon();
			}
		}

		[Constructable]
		public FancyCounter2SouthAddonDeed()
		{
			Name = "FancyCounter2South";
		}

		public FancyCounter2SouthAddonDeed( Serial serial ) : base( serial )
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