using System;
using Server;
using Server.Gumps;
using Server.Network;
using System.Collections;
using Server.Multis;
using Server.Mobiles;


namespace Server.Items
{

	public class FishTankCrafterBasket : Item
	{
		[Constructable]
		public FishTankCrafterBasket() : this( null )
		{
		}

		[Constructable]
		public FishTankCrafterBasket ( string name ) : base ( 0x24D5 )
		{
			Name = "Fish Tank Crafter Basket";
                  		LootType = LootType.Blessed;
			Hue = 0;
		}

		public FishTankCrafterBasket ( Serial serial ) : base ( serial )
		{
		}

      		
		public override void OnDoubleClick( Mobile m )

		{
			Item a = m.Backpack.FindItemByType( typeof(EmptyKegForPaint) );
			if ( a != null )
			{	
			Item b = m.Backpack.FindItemByType( typeof(FullJarsOfBluePaint) );
			if ( b != null )
			{
			Item c = m.Backpack.FindItemByType( typeof(PaintKegLid) );
			if ( c != null )
			{
			
				m.AddToBackpack( new FullKegOfPaint() );
				a.Delete();
				b.Delete();
				c.Delete();
				m.SendMessage( "You have created a Full Keg Of Paint" );
				this.Delete();
			}
			}
				else
			{
				m.SendMessage( "You are missing something..." );
		}
		}
		}
		
		

		public override void Serialize ( GenericWriter writer)
		{
			base.Serialize ( writer );

			writer.Write ( (int) 0);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize ( reader );

			int version = reader.ReadInt();
		}
	}
}