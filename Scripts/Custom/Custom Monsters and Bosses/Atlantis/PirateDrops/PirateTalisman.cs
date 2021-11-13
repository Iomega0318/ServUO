using System;
using Server;

namespace Server.Items
{
	public class PirateTalisman : BaseTalisman
	{
		public override int LabelNumber{ get{ return 1024246; } } // Talisman
                
                
                  

		[Constructable]
		public PirateTalisman() : base( 0x2F5A )
		{
			ItemID = Utility.RandomList(12120,12121,12122,12123);
			Weight = 1.0;
                        Hue = 2995;

						Attributes.CastRecovery = 1;
                        Attributes.CastSpeed = 1;
                        Attributes.DefendChance = 1;
                       
                      
                        Attributes.RegenMana = 2;
                        Attributes.RegenStam = 2;
               
                        Attributes.Luck = 25;
                       
                     
                       
		}

		public PirateTalisman ( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}