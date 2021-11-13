using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class PaintKegLidsJournal: BaseBook
	{
		private const string TITLE = "Paint Keg Lids Journal";
		private const string AUTHOR = "Preston";
		private const int PAGES = 2;
		private const bool WRITABLE = false;
		
		[Constructable]
		public PaintKegLidsJournal()  : base(0xFF0 )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			//  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;

			lines = new string[]
			{
				"Rhodan Has", 
				"The Paints which",
                                                                "You need, travel",
                                                                "Brit, she is near",
				"The docks there", 
                                                                "To gather your next",
				"special item", 
                                
                                
				

			};
			Pages[cnt++].Lines = lines;

			lines = new string[]
			{
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
			};
			Pages[cnt++].Lines = lines;



		}

		public  PaintKegLidsJournal( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); 
		}
	}
}