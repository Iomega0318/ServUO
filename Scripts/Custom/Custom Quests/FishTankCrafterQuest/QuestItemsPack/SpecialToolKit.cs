using System;
using Server;
using Server.Items;
namespace Server.Items
{
        
	public class SpecialToolKit :  Item
	{


		 [Constructable]
		public SpecialToolKit (): base( 0x1EB7 )
		{
			Weight = 1.0; 
            		Name = "Special Tool Kit"; 
            		ItemID = 7863;                                
                        
			}  


		public SpecialToolKit( Serial serial ) : base( serial )
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