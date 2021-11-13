using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class CandyHalloweenBoneHarvester : Food
	{

		[Constructable]
		public CandyHalloweenBoneHarvester() : this( 1 )
		{
		}
		
		[Constructable]
		public CandyHalloweenBoneHarvester( int amount ) : base( 0xF8F, amount )
		{
			this.Stackable = true;
			this.Name = "candy halloween bone harvester";
            Hue = 1106;
			this.ItemID = 9915;
            Layer = Layer.OneHanded;
			this.Amount = amount;
			this.Weight = 1;
			this.FillFactor = 1;
		}

		public CandyHalloweenBoneHarvester( Serial serial ) : base( serial )
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