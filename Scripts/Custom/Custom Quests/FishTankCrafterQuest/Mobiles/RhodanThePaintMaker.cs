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
	[CorpseName( "the paint maker corpse" )]
	public class RhodanThePaintMaker : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public RhodanThePaintMaker()
		{
	        Name = "Rhodan";
                        Title = "*The Paint Maker*";
                        Body = 401;
                        Female = true;
	        Hue = 33774;
                         Blessed = true;

	                    Sandals sa = new Sandals();
                        sa.Hue = 206;
                        sa.LootType = LootType.Blessed;
                        AddItem( sa );

                        ShortPants sp = new ShortPants();
                        sp.Hue = 1104;
                        sp.LootType = LootType.Blessed;
                        AddItem( sp );

	                    Shirt sh = new Shirt();
                        sh.Hue = 191;
                        sh.LootType = LootType.Blessed;
                        AddItem( sh );

                        FullApron fa = new FullApron() ; 
                        fa.Hue = 1166;
                        fa.LootType = LootType.Blessed;
	                    AddItem( fa );

                        WideBrimHat wbh = new  WideBrimHat();
                        wbh.Hue = 1287;
                        wbh.LootType = LootType.Blessed;
                        AddItem( wbh);

                        LeatherGloves lg = new  LeatherGloves();
                        lg.Hue = 1278;
                        lg.LootType = LootType.Blessed;
                        AddItem( lg );
                        

                         Item hair = new Item(8265);
                        hair.Hue = 1110;
                        hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);


                      
			
		}

		public  RhodanThePaintMaker( Serial serial ) : base( serial )
		{
		}

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new  PaintMakerGumpEntry( from, this ) ); 
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

		public class PaintMakerGumpEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public PaintMakerGumpEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( PaintMakerGump ) ) )
					{
						mobile.SendGump( new PaintMakerGump( mobile ));

						
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
				if( dropped is RedAppleWovenCloth )
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "thanks for helping me get this beautiful cloth!", mobile.NetState );
         				return false;
         			}

					dropped.Delete();

                    mobile.AddToBackpack(new FullJarsOfBluePaint());
                   // mobile.AddToBackpack(new VikingPirateJournal());
					mobile.SendMessage( "Thanks for getting this beautiful cloth!" );

				
					return true;
         		}
				else if ( dropped is FullJarsOfBluePaint )
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
