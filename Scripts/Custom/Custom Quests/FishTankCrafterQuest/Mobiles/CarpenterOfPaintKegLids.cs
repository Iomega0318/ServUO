using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( " Barrel Lid Capenter corpse" )]
	public class   BarrelLidCapenter: Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public  BarrelLidCapenter()
		{
			Name = "Preston";
                                            Title = "*Carpenter Of Paint Keg Lids*";
			Body = 400;
			Hue = 1004;
                                                Female = false;
                                                Blessed = true;

	        ShortPants sp = new ShortPants();
                        sp.Hue = 1103;
                        sp.LootType = LootType.Blessed;
                        AddItem( sp );

                        Doublet d = new  Doublet();
                        d.Hue = 300;
                        d.LootType = LootType.Blessed;
                        AddItem( d );


                        Sandals s = new Sandals();
                        s.Hue = 300;
                        s.LootType = LootType.Blessed;
                        AddItem( s );

                         Item hair = new Item(8253);
                         hair.Hue = 1510;
                          hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);

                        
                        LeatherGloves lg = new LeatherGloves();
                        lg.Hue = 1103;
                        lg.LootType = LootType.Blessed;
                        AddItem( lg );



                      
		}

		public  BarrelLidCapenter( Serial serial ) : base( serial )
		{
		}

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)  
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new BarrelLidCapenterEntry( from, this ) ); 
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

		public class BarrelLidCapenterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public BarrelLidCapenterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}

			public override void OnClick()
			{
				

                          if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;

				{
					if ( ! mobile.HasGump( typeof( BarrelLidCapenterGump ) ) )
					{
						mobile.SendGump( new BarrelLidCapenterGump( mobile ));
//
						
					} 
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;

			if ( mobile != null)
			{
				if( dropped is HeavySteelSkillet )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "ahhh the Heavy Steel Skillet!", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
										
					mobile.AddToBackpack( new PaintKegLid() );
                    mobile.AddToBackpack(new PaintKegLidsJournal());
					mobile.SendMessage( "Good luck to you!");

				
					return true;
         		}
				else if ( dropped is PaintKegLid )
				{
				this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );
         			return false;
				}
         		else
         		{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Why on earth would I want to have that?", mobile.NetState );
     			}
			}
			return false;
		}
	}
}
