using System;
using Server;

namespace Server.Items
{	


                               public class AtlantisBrazier : Item
                               
	             {
		[Constructable]
		public AtlantisBrazier() : base( 0x1244)
		{                
			
                                                Weight = 2;
                                                Name = "Atlantis Brazier";
			                        Hue = 2990;
                                                ItemID = 6571;   
                                                
		}

		public AtlantisBrazier( Serial serial ) : base(serial)
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