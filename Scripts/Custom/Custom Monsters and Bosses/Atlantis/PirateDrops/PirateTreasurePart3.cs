using System;
using Server;

namespace Server.Items
{	


                               public class PirateTreasurePart3 : Item
                               
	             {
		[Constructable]
		public PirateTreasurePart3() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Pirate Treasure";
			                        Hue = 0;
                                                ItemID = 7018;   
                                                
		}

		public PirateTreasurePart3( Serial serial ) : base(serial)
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