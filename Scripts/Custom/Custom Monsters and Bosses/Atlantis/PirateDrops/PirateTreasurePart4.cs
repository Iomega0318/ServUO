using System;
using Server;

namespace Server.Items
{	


                               public class PirateTreasurePart4 : Item
                               
	             {
		[Constructable]
		public PirateTreasurePart4() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Pirate Treasure";
			                        Hue = 0;
                                                ItemID = 7008;   
                                                
		}

		public PirateTreasurePart4( Serial serial ) : base(serial)
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