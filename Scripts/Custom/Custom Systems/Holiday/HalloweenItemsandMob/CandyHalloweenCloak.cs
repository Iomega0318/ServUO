using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class CandyHalloweenCloak : Food
	{

		[Constructable]
		public CandyHalloweenCloak() : this( 1 )
		{
		}
		
		[Constructable]
		public CandyHalloweenCloak( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "a candy halloween cloak";
                        Hue = 1259;
			this.ItemID = 8970;
                        Layer = Layer.Cloak;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 1;
            BuffStat = StatType.Dex;
            BuffIntensity = 1;
        }

		public CandyHalloweenCloak( Serial serial ) : base( serial )
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
