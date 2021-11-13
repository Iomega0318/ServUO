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
	[CorpseName( "the keg crafter corpse" )]
	public class  NathanTheKegCrafter: Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public NathanTheKegCrafter()
		{
			Name = "Nathan";
                                            Title = "*The Keg Crafter*";
			Body = 400;
			Hue = 1004;
                                                Female = false;
                                                Blessed = true;

                        LongPants p = new LongPants();
                        p.Hue = 1367;
                        p.LootType = LootType.Blessed;
                        AddItem( p );

                        Shirt s = new Shirt();
                        s.Hue = 480;
                        s.LootType = LootType.Blessed;
                        AddItem( s );

                        Boots b = new Boots();
                        b.Hue = 1367;
                        b.LootType = LootType.Blessed;
                        AddItem( b );

                        
                        Bandana ba = new   Bandana ();
                        ba.Hue = 480;
                        ba.LootType = LootType.Blessed;
                        AddItem( ba );

                        
                        LeatherGloves lg = new LeatherGloves();
                        lg.Hue = 1367;
                        lg.LootType = LootType.Blessed;
                        AddItem( lg );

                        Item hair = new Item( 8252);
                        hair.Hue = 1126;
                        hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);


                                                   
                          }

		public NathanTheKegCrafter( Serial serial ) : base( serial )
		{
		}

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)  
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new NathanTheKegCrafterEntry( from, this ) ); 
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

		public class NathanTheKegCrafterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public NathanTheKegCrafterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( NathanKegCrafterGump ) ) )
					{
                        mobile.SendGump(new NathanKegCrafterGump(mobile));

						
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
				if( dropped is SpecialToolKit )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "ahhh the special tool kit!", mobile.NetState );
         				return false;
         			}

					dropped.Delete(); 
										
					mobile.AddToBackpack( new EmptyKegForPaint() );
                    mobile.AddToBackpack(new KegCrafterBook());
					mobile.SendMessage( "Best of the day to you!");

				
					return true;
         		}
				else if ( dropped is SpecialToolKit )
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
