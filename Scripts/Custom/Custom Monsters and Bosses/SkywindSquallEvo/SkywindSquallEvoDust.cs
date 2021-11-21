using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Xanthos.Evo
{
	public class SkywindSquallDust : BaseEvoDust
	{
		[Constructable]
		public SkywindSquallDust() : this( 500 )
		{
		}

		[Constructable]
		public SkywindSquallDust( int amount ) : base( amount )
		{
			Amount = amount;
			Name = "Skywind Squall Dust";
			Hue = 1372;
		}

		public SkywindSquallDust( Serial serial ) : base ( serial )
		{
		}

		public override BaseEvoDust NewDust()
		{
			return new SkywindSquallDust();
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