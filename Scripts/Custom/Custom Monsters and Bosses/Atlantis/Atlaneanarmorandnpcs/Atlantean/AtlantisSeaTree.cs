using System;
using Server;

namespace Server.Items
{	


                               public class AtlantisSeaTree : Item
                               
	             {
		[Constructable]
		public AtlantisSeaTree() : base( 0x1244)
		{                
			
                                                Weight = 15;
                                                Name = "Atlantis Sea Tree";
			                        Hue = 2990;
                                                ItemID = 3280;   
                                                
		}

		public AtlantisSeaTree( Serial serial ) : base(serial)
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