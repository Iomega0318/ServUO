using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachCapturedFlight : Item
                               
	             {
		[Constructable]
		public SkywardReachCapturedFlight() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "SkywardReach Captured Flight";
			    Hue = 0;
                ItemID = 24770;   
                                                
		}

		public SkywardReachCapturedFlight( Serial serial ) : base(serial)
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