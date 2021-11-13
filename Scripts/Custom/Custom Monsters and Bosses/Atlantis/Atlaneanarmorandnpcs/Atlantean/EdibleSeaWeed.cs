using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class EdibleSeaWeed : Food
	{

		[Constructable]
		public EdibleSeaWeed() : this( 1 )
		{
		}
		
		[Constructable]
		public EdibleSeaWeed( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "Edible Sea Weed";
            Hue = 2946;
			this.ItemID = 3184;
            Layer = Layer.OneHanded;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 25;
		}

		public EdibleSeaWeed( Serial serial ) : base( serial )
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