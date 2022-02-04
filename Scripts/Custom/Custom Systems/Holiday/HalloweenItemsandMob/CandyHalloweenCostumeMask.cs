using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class CandyHalloweenCostumeMask : Food
	{

		[Constructable]
		public CandyHalloweenCostumeMask() : this( 1 )
		{
		}
		
		[Constructable]
		public CandyHalloweenCostumeMask( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "candy halloween costume mask";
                        Hue = 1207;
			this.ItemID = 5449;
                        Layer = Layer.Helm;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 1;
            BuffStat = StatType.Dex;
            BuffIntensity = 1;
        }

		public CandyHalloweenCostumeMask( Serial serial ) : base( serial )
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
