using System;
using System.Collections;
using Server;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
    [CorpseName("a  leprechaun ")]
	public class   Leprechaun: BaseCreature
	{
		private static bool m_Talked;
        string[]  LeprechaunSay  = new string[] 
		{ 
			"My pot of gold,", 
			"So you want to steal it",
			"Not My pot of gold",
			"Never you will die first",
		};  

		public override bool ClickTitle{ get{ return false; } }		

		[Constructable]
		public  Leprechaun() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
            Name = "The Leprechaun";
			
                        Body = 400;
			Hue = 1003;

		
			{
				
			

			   AddItem( new LeprechaunCloakBL () );
                        AddItem( new LeprechaunPantsBL () );
                        AddItem( new LeprechaunBootsBL () );
                        AddItem( new LeprechaunShirtBL () );
                        AddItem( new LeprechaunHat1BL () );
                        AddItem( new ShillelaghBL () );
                        AddItem( new StPatricksDay2010BL () );

                        Item beard = new Item(8267);
                        beard.Hue = 33;
                        beard.Layer = Layer.FacialHair;
                        beard.Movable = false;
                        AddItem(beard);

                        Item hair = new Item(8251);
                        hair.Hue = 33;
                        hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);
	

                  }
                                                 SetStr( 110, 125 );
 			SetDex( 191, 215 );
			SetInt( 126, 150 );

			SetHits( 1000, 1200 );

			SetDamage( 30, 40 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Fire, 90, 95 );
			SetResistance( ResistanceType.Cold, 80, 85 );
			SetResistance( ResistanceType.Poison, 100, 105 );
			SetResistance( ResistanceType.Energy, 100, 110 );

			SetSkill( SkillName.EvalInt, 90.2, 100.0 );
			SetSkill( SkillName.Magery, 100.1, 110.0 );
			SetSkill( SkillName.Meditation, 90.5, 100.0 );
			SetSkill( SkillName.MagicResist, 115.5, 120.0 );
			SetSkill( SkillName.Tactics, 115.0, 120.5 );
			SetSkill( SkillName.Wrestling, 110.3, 115.0 );

		

			Fame = 4000;
			Karma = -1000;
            VirtualArmor = 75;

			
		
            Container pack = new Backpack();
			PackItem( new Gold( 700, 800 ) );
			 AddItem( pack );
			
			
			  
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
            		   			SayRandom(  LeprechaunSay, this ); 
           		   			this.Move( GetDirectionTo( m.Location ) );
             		   			SpamTimer t = new SpamTimer(); 
           		   			t.Start(); 
            				} 
        	  		} 
			}

			public override bool OnBeforeDeath()
			{
				this.Say( "The Pot Of Gold Is Mine!" );
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

            public Leprechaun(Serial serial)
                : base(serial)
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
