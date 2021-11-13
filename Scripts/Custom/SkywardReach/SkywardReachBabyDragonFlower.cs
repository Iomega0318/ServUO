using System;
using Server;

namespace Server.Items
{	


                               public class SkywardReachBabyDragonFlower : Item
                               
	             {
		[Constructable]
		public SkywardReachBabyDragonFlower() : base( 0x1244)
		{                
			
                Weight = 1;
                Name = "Skyward Reach Baby Dragon Flower";
			    Hue = 0;
                ItemID = 24652;   
                                                
		}

		public SkywardReachBabyDragonFlower( Serial serial ) : base(serial)
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