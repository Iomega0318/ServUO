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
	public class TortureBlockAddon : BaseAddon
	{
		public override BaseAddonDeed Deed
		{
			get
			{
				return new TortureBlockAddonDeed();
			}
		}

		[ Constructable ]
		public TortureBlockAddon()
		{
			AddonComponent ac;
			ac = new AddonComponent( 4715 );
			AddComponent( ac, 1, 1, 0 );
			ac = new AddonComponent( 4716 );
			AddComponent( ac, 1, 0, 0 );
			ac = new AddonComponent( 4720 );
			AddComponent( ac, 0, 1, 0 );
			ac = new AddonComponent( 4719 );
			AddComponent( ac, 0, 0, 0 );
			ac = new AddonComponent( 4722 );
			AddComponent( ac, -1, 0, 0 );
			ac = new AddonComponent( 4721 );
			AddComponent( ac, -1, 1, 0 );
			ac = new AddonComponent( 4723 );
			AddComponent( ac, -1, -1, 0 );
			ac = new AddonComponent( 4718 );
			AddComponent( ac, 0, -1, 0 );
			ac = new AddonComponent( 4717 );
			AddComponent( ac, 1, -1, 0 );
			ac = new AddonComponent( 6921 );
			AddComponent( ac, 1, 1, 2 );

		}

		public TortureBlockAddon( Serial serial ) : base( serial )
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

	public class TortureBlockAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new TortureBlockAddon();
			}
		}

		[Constructable]
		public TortureBlockAddonDeed()
		{
			Name = "TortureBlock";
		}

		public TortureBlockAddonDeed( Serial serial ) : base( serial )
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