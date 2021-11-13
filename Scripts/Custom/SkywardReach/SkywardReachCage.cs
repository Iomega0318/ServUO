using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachCage : Item
                               
	             {
		[Constructable]
		public SkywardReachCage() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "SkywardReach Cage";
			    Hue = 1150;
                ItemID = 424770;   
                                                
		}

		public SkywardReachCage( Serial serial ) : base(serial)
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