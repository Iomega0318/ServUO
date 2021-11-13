using System;
using Server;

namespace Server.Items
{
	// books: Brown 0xFEF, Tan 0xFF0, Red 0xFF1, Blue 0xFF2, 
	// OpenSmall 0xFF3, Open 0xFF4, OpenOld 0xFBD, 0xFBE

	public class KegCrafterBook: BaseBook
	{
		private const string TITLE = "Keg Crafter Ramblings";
		private const string AUTHOR = "Nathan";
		private const int PAGES = 2;
		private const bool WRITABLE = false;
		
		[Constructable]
		public KegCrafterBook() : base(0xFF0 )
		{
			// NOTE: There are 8 lines per page and
			// approx 22 to 24 characters per line.
			//  0----+----1----+----2----+
			int cnt = 0;
			string[] lines;

			lines = new string[]
			{
			"To Find The Carpenter", 
            "Of Paint Keg Lids",  
            "Travel To Moonglow", 
			"His Shop Is Right",
            "Outside The Town",
			"Moonglow",
            "South on a farm",
				
				

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

        public KegCrafterBook(Serial serial)
            : base(serial)
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