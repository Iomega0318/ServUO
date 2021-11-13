using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class CandyHalloweenShoes : Food
	{

		[Constructable]
		public CandyHalloweenShoes() : this( 1 )
		{
		}
		
		[Constructable]
		public CandyHalloweenShoes( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "candy halloween shoes";
                        Hue = 1259;
			this.ItemID = 5903;
                        Layer = Layer.Shoes;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 1;
		}

		public CandyHalloweenShoes( Serial serial ) : base( serial )
		{
		}

		//public override Item Dupe( int amount )
		
			//return base.Dupe( new CandyHeart( amount ), amount );
		
	
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