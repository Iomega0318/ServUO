using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachBabySongBirdInCage : Item
                               
	             {
		[Constructable]
		public SkywardReachBabySongBirdInCage() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "SkywardReach Baby Song Bird In Cage";
			    Hue = 0;
                ItemID = 24635;   
                                                
		}

		public SkywardReachBabySongBirdInCage( Serial serial ) : base(serial)
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