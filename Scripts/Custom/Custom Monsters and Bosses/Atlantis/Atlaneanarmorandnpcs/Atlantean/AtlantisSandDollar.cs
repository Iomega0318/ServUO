using System;
using Server;

namespace Server.Items
{	


                               public class AtlantisSandDollar : Item
                               
	             {
		[Constructable]
		public AtlantisSandDollar() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Atlantis Sand Dollar";
			                        Hue = 2523;
                                                ItemID = 15125;   
                                                
		}

		public AtlantisSandDollar( Serial serial ) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}