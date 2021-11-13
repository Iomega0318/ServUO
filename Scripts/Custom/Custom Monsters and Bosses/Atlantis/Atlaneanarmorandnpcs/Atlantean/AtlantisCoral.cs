using System;
using Server;

namespace Server.Items
{	


                               public class AtlantisCoral : Item
                               
	             {
		[Constructable]
		public AtlantisCoral() : base( 0x1244)
		{                
			
                                                Weight = 5;
                                                Name = "Atlantis Coral";
			                        Hue = 2857;
                                                ItemID = 15099;   
                                                
		}

		public AtlantisCoral( Serial serial ) : base(serial)
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