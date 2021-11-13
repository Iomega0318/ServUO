using System;
using Server;

namespace Server.Items
{	


                               public class AtlantisSeaLoft : Item
                               
	             {
		[Constructable]
		public AtlantisSeaLoft() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Atlantis Sea Loft";
			                        Hue = 2857;
                                                ItemID = 9325;   
                                                
		}

		public AtlantisSeaLoft( Serial serial ) : base(serial)
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