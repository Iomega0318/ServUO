using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a Skyward Avenger" )]
	public class SkywardAvenger : BaseCreature
	{
		private static bool m_Talked;
		string[] SkywardAvengerSay = new string[] 
		{ 
			"Turn Back Now, You have No Chance you pathetic Fool", 
			"Only One With The Wind Beneath His Wings Could ever Master SkyWind Squall",
			"You Shall Fall A thousand Flights Your Death",
			"Suffering The Wrath Of Skyward Reach Champions"
		}; 

		public override bool ClickTitle{ get{ return false; } }		

		[Constructable]
		public SkywardAvenger() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "The Wrath";
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Name = "SkyDawn";
				Body = 0x191;

			Item Shirt = new Item( 7933 );
			Shirt.Hue = 0;
			Shirt.Layer = Layer.Shirt;
			Shirt.LootType = LootType.Blessed;
			AddItem( Shirt );

			SkywardReachSlasher weapon = new SkywardReachSlasher();
			weapon.Movable = false;
            AddItem( weapon );

			SkywardReachSquallPendant necklace = new SkywardReachSquallPendant();
			necklace.Movable = false;
            AddItem( necklace );

			SkywardReachFlight cloak = new SkywardReachFlight();
			cloak.Movable = false;
            AddItem( cloak );

			SkywardReachWingedHelm helmet = new SkywardReachWingedHelm();
			helmet.Movable = false;
            AddItem( helmet );

			}
			else
			{
				Body = 0x190;
				Name = "SkyDusk";

			Item LongPants = new Item( 5433 );
			LongPants.Hue = 1107;
			LongPants.Layer = Layer.Pants;
			LongPants.LootType = LootType.Blessed;
			AddItem( LongPants );

			SkywardReachFeatheredCloak cloak = new SkywardReachFeatheredCloak();
			cloak.Movable = false;
            AddItem( cloak );

			SkywardReachSlasher weapon = new SkywardReachSlasher();
			weapon.Movable = false;
            AddItem( weapon );


			}

			SetStr( 250 );
			SetDex( 190 );
			SetInt( 280 );
			SetHits( 1000, 1250 );

			SetDamage( 20, 28 );

			SetSkill( SkillName.MagicResist, 180.5 );
			SetSkill( SkillName.Swords, 220.5 );
			SetSkill( SkillName.Tactics, 135.0, 160.5 );
			SetSkill( SkillName.Wrestling, 220.3 );

			Fame = 4000;
			Karma = -1000;
            VirtualArmor = 75;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
		
            Container pack = new Backpack();
			PackItem( new Gold( 1000, 2000 ) );
			
			if ( 0.45 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop 
			switch ( Utility.Random( 9 ))//number of alternatives 
			  
			// Armors 
		
			{
			
                      
             case 0:	AddToBackpack( new SkywardReachWovenClawGown() ); break;
             case 1:	AddToBackpack( new SkywardReachFlight() ); break;
             case 2:	AddToBackpack( new SkywardReachCapturedFlight() ); break;
             case 3:	AddToBackpack( new SkywardReachWingedHelm() ); break;
             case 4:	AddToBackpack( new SkywardReachSlasher() ); break;
             case 5:	AddToBackpack( new SkywardReachDragonFlower() ); break;
             case 6:	AddToBackpack( new SkywardReachFeatheredCloak() ); break;
			 case 7:	AddToBackpack( new SkywardReachDreamCapture4() ); break;
			 
			  
            }
        }
          
			public override int TreasureMapLevel{ get{ return 32; } }
		
			public override void GenerateLoot()
			{
				AddLoot( LootPack.Average );
			}

			public override bool AlwaysMurderer{ get{ return true; } }

        		public override void OnMovement( Mobile m, Point3D oldLocation ) 
                	{                                                    
       		  		if( m_Talked == false ) 
        	  		{ 
      		      			if ( m.InRange( this, 3 ) && m is PlayerMobile) 
        				{                
            		   			m_Talked = true; 
            		   			SayRandom( SkywardAvengerSay, this ); 
           		   			this.Move( GetDirectionTo( m.Location ) );
             		   			SpamTimer t = new SpamTimer(); 
           		   			t.Start(); 
            				} 
        	  		} 
			}

			public override bool OnBeforeDeath()
			{
				this.Say( "We Shall Prevail.... We Shall Avenge thee!" );
				return base.OnBeforeDeath();
			}

    	  		private class SpamTimer : Timer 
			{ 
		   		public SpamTimer() : base( TimeSpan.FromSeconds( 12 ) ) 
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

			public SkywardAvenger( Serial serial ) : base( serial )
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
