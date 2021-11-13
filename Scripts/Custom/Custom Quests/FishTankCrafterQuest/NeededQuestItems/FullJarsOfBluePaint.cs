using System;
using Server;
using Server.Items;
namespace Server.Items
{
        
	public class FullJarsOfBluePaint :  Item
	{


		
		[Constructable]
		public FullJarsOfBluePaint (): base( 0xE4B )
		{
			Weight = 1.0; 
            		Name = "Full Jars Of Blue Paint "; 
            		Hue = 396;
                                ItemID = 3659;                                
                        
			}  


		public  FullJarsOfBluePaint ( Serial serial ) : base( serial )
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