using System;
using Server;
using Server.Items;
using System.Collections;


namespace Server.Mobiles
{

	[CorpseName( "a santa greeter corpse" )]
	public class santagreeter : BaseCreature
	{
           private static bool m_Talked; // flag to prevent spam 

      string[] kfcsay = new string[] // things to say while greating 
      { 
         "Ho Ho Ho", 
             "Welcome To The North Pole", 
            "Hope You Have Been Good This Year", 
            
             
      };
                 

		[Constructable]
		public  santagreeter () : base( AIType.AI_Healer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			
                        
			
		        Body = 400;
			Hue = 33770;
                                                Name = "Santa Clause";
                        ActiveSpeed = 0.4;
			
			SetStr( 100 );
			SetDex( 100 );
			SetInt( 100 );

                        SetDamage( 1, 1 );

			SetHits( 3000 );

                        Fame = 0;
			Karma = 0;
                        
                       Item longpants;
			longpants = new LongPants();
			longpants.Hue = 1109;
			AddItem( longpants );
                         longpants.LootType = LootType.Newbied;

			Item tunic;
			tunic = new Tunic();
			tunic.Hue = 33;
			AddItem( tunic );
                        tunic.LootType = LootType.Newbied;

                        Item LongHair = new LongHair(8252);
			LongHair .Movable = false;
                        LongHair .Hue = 1153;
			AddItem( LongHair  );

			

			Item leatherninjabelt;
			leatherninjabelt = new LeatherNinjaBelt();
			leatherninjabelt.Hue = 1109;
			AddItem( leatherninjabelt );
                        leatherninjabelt.LootType = LootType.Newbied;

			Item boots;
			boots = new Boots();
			boots.Hue = 1109;
			AddItem( boots );
                        boots.LootType = LootType.Newbied;

			Item JesterHat;
			JesterHat = new JesterHat();
			JesterHat.Hue = 33;
			AddItem( JesterHat );
                                  JesterHat.LootType = LootType.Newbied;

                        

			
                        
		 

}

		
                public override bool CanRummageCorpses{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 3; } }
		

                public override void GenerateLoot()
		{
                        Container pack = new Backpack(); 
                 pack.DropItem( new Gold( 1000, 2000 ) ); 
	          pack.Movable = false; 
                 AddItem( pack );

			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls, 2 );
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
		public santagreeter( Serial serial ) : base( serial )
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
