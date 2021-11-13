using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "Elder Pirate" )]
	public class ElderPirate : BaseCreature
	{
           private static bool m_Talked; // flag to prevent spam 

      string[] kfcsay = new string[] // things to say while greating 
      { 
         "Captain, I Have Spotted An Intuder On The Horizon", 
         "We were so carefull in our quest, I don't know how we could have been followed",
		 "Man Your Stations, Prepare To Protect The treasure",
		 "This can Not be jepordized it has taken us to long to find the lost city of Atlantis",
		 "All Weapons ready",
      };
                 

		[Constructable]
		public ElderPirate () : base( AIType.AI_Healer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "male" );
                        Title = "Elder";
			
		        Body = 400;
			Hue = 33770;
                        ActiveSpeed = 0.4;
			
			SetStr( 150 );
			SetDex( 200 );
			SetInt( 100 );

                        SetDamage( 20, 25 );

			SetHits( 600, 800 );

                        Fame = 3000;
			Karma = 500;
                        


			Item longpants;
			longpants = new LongPants();
			longpants.Hue = 1810;
			AddItem( longpants );
                        longpants.LootType = LootType.Newbied;

			Item bodysash;
			bodysash = new BodySash();
			bodysash.Hue = 1810;
			AddItem( bodysash );
                        bodysash.LootType = LootType.Newbied;

                        Item LongHair = new LongHair(2101);
			LongHair.Movable = false;
			AddItem( LongHair );


			Item fancyshirt;
			fancyshirt = new FancyShirt();
			fancyshirt.Hue = 291;
			AddItem( fancyshirt );
                        fancyshirt.LootType = LootType.Newbied;

			Item Boots;
			Boots = new Boots();
			Boots.Hue = 1;
			AddItem( Boots );

			Item WideBrimHat;
			WideBrimHat = new WideBrimHat();
			WideBrimHat.Hue = 1810;
			AddItem( WideBrimHat );
                        
		 

}

		
                public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 20; } }
		

                public override void GenerateLoot()
		{
                        Container pack = new Backpack(); 
                 pack.DropItem( new Gold( 300, 400 ) ); 
	          pack.Movable = false; 
                 AddItem( pack );

			AddLoot( LootPack.Rich, 15 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls, 10 );
		}
		
                public override void OnMovement( Mobile m, Point3D oldLocation ) 
               {                                                    
         if( m_Talked == false ) 
         { 
            if ( m.InRange( this, 4 ) ) 
            {                
               m_Talked = true; 
               SayRandom( kfcsay, this ); 
               this.Move( GetDirectionTo( m.Location ) ); 
                  // Start timer to prevent spam 
               SpamTimer t = new SpamTimer(); 
               t.Start(); 
            } 
         } 
      } 

      private class SpamTimer : Timer 
      { 
         public SpamTimer() : base( TimeSpan.FromSeconds( 8 ) ) 
         { 
            Priority = TimerPriority.OneSecond; 
         } 

         protected override void OnTick() 
         { 
            m_Talked = false; 
         } 
      } 

      private static void SayRandom( string[] say, Mobile m ) 
      { 
         m.Say( say[Utility.Random( say.Length )] ); 
      } 
		public ElderPirate( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
