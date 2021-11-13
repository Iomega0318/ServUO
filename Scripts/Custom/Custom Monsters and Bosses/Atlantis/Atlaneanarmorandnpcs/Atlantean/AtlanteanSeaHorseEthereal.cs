/////Soul Taker////////////////////////////////////////////////////
using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;

namespace Server.Mobiles
{
	

	public class AtlanteanSeaHorseEthereal : EtherealMount
	{
		public override int LabelNumber{ get{ return 1049749; } } // Atlantean Ethereal Seahorse Statuette

		[Constructable]
		public AtlanteanSeaHorseEthereal() : base( 0x25BA, 0x3EB3, 0x3EB3, DefaultEtherealHue )
		{
			Name = "atlantean ethereal sea horse statuette";
			Hue = 1159;
		}

		public AtlanteanSeaHorseEthereal( Serial serial ) : base( serial )
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

			if ( Name == "an ethereal sea horse" )
				Name = null;
                 }

		public override void OnAdded( object parent )
		{
			base.OnAdded( parent );
			if( parent is Mobile )
			{
				Mobile from = (Mobile)parent;
				from.CanSwim = true;
			}
		}
	}
}
