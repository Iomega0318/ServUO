using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachDreamCapture2 : Item
                               
	             {
		[Constructable]
		public SkywardReachDreamCapture2() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "SkywardReach Dream Capture";
			    Hue = 0;
                ItemID = 16639;   
                                                
		}

		public SkywardReachDreamCapture2( Serial serial ) : base(serial)
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