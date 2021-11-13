using System;
using Server;
using Server.Items;
namespace Server.Items
{
        
	public class RedAppleWovenCloth :  Item
	{


		
		[Constructable]
		public RedAppleWovenCloth (): base( 0x1767 )
		{
			Weight = 1.0; 
            		Name = "Red Apple Woven Cloth"; 
            		Hue = 38;
                                ItemID = 5991;                                
                        
			}  


		public RedAppleWovenCloth  ( Serial serial ) : base( serial )
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