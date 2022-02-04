using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class CandyHalloweenCostume : Food
	{

		[Constructable]
		public CandyHalloweenCostume() : this( 1 )
		{
		}
		
		[Constructable]
		public CandyHalloweenCostume( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "a candy halloween costume";
                        Hue = 1107;
			this.ItemID = 10114;
                        Layer = Layer.OuterTorso;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 1;
            BuffStat = StatType.Dex;
            BuffIntensity = 1;
        }

		public CandyHalloweenCostume( Serial serial ) : base( serial )
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
