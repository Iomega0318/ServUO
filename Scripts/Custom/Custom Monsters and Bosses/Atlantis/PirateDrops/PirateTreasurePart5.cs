using System;
using Server;

namespace Server.Items
{	


                               public class PirateTreasurePart5 : Item
                               
	             {
		[Constructable]
		public PirateTreasurePart5() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Pirate Treasure";
			                        Hue = 0;
                                                ItemID = 7010;   
                                                
		}

		public PirateTreasurePart5( Serial serial ) : base(serial)
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