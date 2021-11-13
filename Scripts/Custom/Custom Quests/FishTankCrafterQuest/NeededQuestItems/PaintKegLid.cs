using System;
using Server;
using Server.Items;
namespace Server.Items
{
        
	public class PaintKegLid :  Item
	{


		 [Constructable]
		public PaintKegLid(): base( 0x1DB8 )
		{
			Weight = 1.0; 
            		Name = "PaintKegLid"; 
            		
                        ItemID = 7608;                                
                        
			}


                                public PaintKegLid(Serial serial)
                                    : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}