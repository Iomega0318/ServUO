using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachDragonFlower : Item
                               
	             {
		[Constructable]
		public SkywardReachDragonFlower() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "Skyward Reach Dragon Flower";
			    Hue = 0;
                ItemID = 24696;   
                                                
		}

		public SkywardReachDragonFlower( Serial serial ) : base(serial)
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