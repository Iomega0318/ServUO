/////////////////////////////////////////////////
//                                             //
// Automatically generated by the              //
// AddonGenerator script by Arya               //
//                                             //
/////////////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BlueFirePitAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new BlueFirePitAddonDeed();
			}
		}

		[ Constructable ]
		public BlueFirePitAddon()
		{
			AddonComponent ac;
			ac = new AddonComponent( 47 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 2, 10 );
			ac = new AddonComponent( 50 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 2, 8 );
			ac = new AddonComponent( 50 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 1, 8 );
			ac = new AddonComponent( 50 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 0, 8 );
			ac = new AddonComponent( 9320 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 37 );
			ac.Hue = 2506;
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 37 );
			ac.Hue = 2506;
			AddComponent( ac, 0, 2, 0 );
			ac = new AddonComponent( 38 );
			ac.Hue = 2506;
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 38 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 9323 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 38 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 37 );
			ac.Hue = 2506;
			AddComponent( ac, 1, -1, 0 );
			ac = new AddonComponent( 38 );
			ac.Hue = 2506;
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 38 );
			ac.Hue = 2506;
			AddComponent( ac, -1, 2, 0 );
			ac = new AddonComponent( 36 );
			ac.Hue = 2506;
			AddComponent( ac, 1, 2, 0 );
			ac = new AddonComponent( 47 );
			ac.Hue = 2506;
			AddComponent( ac, 0, 2, 8 );
			ac = new AddonComponent( 14624 );
			ac.Hue = 2504;
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 14624 );
			ac.Hue = 2504;
			AddComponent( ac, 0, 0, 0 );

		}

		public BlueFirePitAddon( Serial serial ) : base( serial )
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

	public class BlueFirePitAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new BlueFirePitAddon();
			}
		}

		[Constructable]
		public BlueFirePitAddonDeed()
		{
			Name = "BlueFirePit";
		}

		public BlueFirePitAddonDeed( Serial serial ) : base( serial )
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