using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class EdibleJellyfish : Food
	{

		[Constructable]
		public EdibleJellyfish() : this( 1 )
		{
		}
		
		[Constructable]
		public EdibleJellyfish( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "EdibleJellyfish";
            Hue = 2960;
			this.ItemID = 9772;
            Layer = Layer.OneHanded;
			this.Amount = amount;
			this.Weight = 2;
			this.FillFactor = 10;
            BuffStat = StatType.Dex;
            BuffIntensity = 1;
        }

		public EdibleJellyfish( Serial serial ) : base( serial )
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
