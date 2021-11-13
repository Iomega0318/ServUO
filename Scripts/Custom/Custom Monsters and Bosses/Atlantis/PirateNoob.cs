using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a corpse of a pirate noob" )]
	public class PirateNoob : BaseCreature
	{
		private static bool m_Talked;
		string[] PirateNoobSay = new string[] 
		{ 
			"Ye be dealing with a pirate, Matey!", 
			"Ye find it wise to cross blades with a pirate, fool?",
			"To the depths ye shall be fallin'!",
			"Yer time has come yeh mongrel."
		}; 

		public override bool ClickTitle{ get{ return false; } }		

		[Constructable]
		public PirateNoob() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the pirate noob";
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );

				Dagger dagger = new Dagger();
				dagger.Movable = false;
				//dagger.Resource = ResourceName.Gold;
				dagger.Skill = SkillName.Wrestling;

				Item necklace = new Necklace();
				necklace.Name = "a pirate's medallion";
				necklace.Movable = false;

				AddItem( dagger );

				AddItem( new Shirt() );

				AddItem( new Skirt( Utility.RandomNeutralHue()) );
	
				AddItem( new HalfApron() );

				AddItem( new Sandals() );

				AddItem( new WoodenShield() );

				AddItem( necklace );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );

				Cutlass cutlass = new Cutlass();
				cutlass.Movable = false;
				//cutlass.Resource = ResourceName.Gold;
				cutlass.Skill = SkillName.Wrestling;

				AddItem( cutlass );

				AddItem( new FancyShirt() );
	
				AddItem( new LongPants( Utility.RandomNeutralHue()) );

				AddItem( new Boots( Utility.RandomNeutralHue()) );

				AddItem( new Buckler() );
	
				AddItem( new BodySash( Utility.RandomRedHue()) );

				AddItem( new TricorneHat( Utility.RandomRedHue()) );
			}

			SetStr( 100 );
			SetDex( 115 );
			SetInt( 125 );
			
			SetHits( 300, 550 );

			SetDamage( 15, 25 );

			SetSkill( SkillName.MagicResist, 100.5 );
			SetSkill( SkillName.Swords, 105.5 );
			SetSkill( SkillName.Tactics, 110.5 );
			SetSkill( SkillName.Wrestling, 115.3 );

			Fame = 2000;
			Karma = -200;
            
			VirtualArmor = 55;

			Item hair = new Item( Utility.RandomList( 0x203B, 0x2049, 0x2048, 0x204A ) );
			hair.Hue = Utility.RandomNondyedHue();
			hair.Layer = Layer.Hair;
			hair.Movable = false;
			AddItem( hair );
		
            Container pack = new Backpack();
			PackItem( new Gold( 0, 1 ) );
			
			if ( 0.40 > Utility.RandomDouble() ) // 0.40 = 45% = chance to drop 
			switch ( Utility.Random( 4 ))//number of alternatives 
			  
			// Armors 
		
			{
			
                      
             case 0:	PackItem( new PirateGorget() ); break;
             case 1:	PackItem( new PirateLegs() ); break;
             case 2:	PackItem( new PirateGauntlets() ); break;
			 case 3:	PackItem( new PirateTreasurePart5() ); break;
             

            }
        }
          
			public override int TreasureMapLevel{ get{ return 1; } }
		
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
            		   			SayRandom( PirateNoobSay, this ); 
           		   			this.Move( GetDirectionTo( m.Location ) );
             		   			SpamTimer t = new SpamTimer(); 
           		   			t.Start(); 
            				} 
        	  		} 
			}

			public override bool OnBeforeDeath()
			{
				this.Say( "Ye've nay seen the last of me! My brethren shall avenge me!" );
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

			public PirateNoob( Serial serial ) : base( serial )
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
