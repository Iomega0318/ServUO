using System;
using Server;
using Server.Items;
namespace Server.Items
{
        
	public class EmptyKegForPaint :  Item
	{


		
		[Constructable]
		public EmptyKegForPaint(): base( 0xE7F )
		{
			Weight = 1.0; 
            		Name = "EmptyKegForPaint"; 
            		
                        ItemID = 3711;                                
                        
			}  


		public EmptyKegForPaint( Serial serial ) : base( serial )
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