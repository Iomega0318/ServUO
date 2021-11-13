using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Accounting;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName( "fish tank crafter corpse" )]
	public class TheFishTankCrafter : Mobile
	{
                public virtual bool IsInvulnerable{ get{ return true; } }
		[Constructable]
		public TheFishTankCrafter ()
		{
			Name = "Ethan";
                                                Title = "*The Fish Tank Crafter*";
			Body = 400;
		                CantWalk = true;
			Hue = 33790;
                                                Blessed = true;

	        ShortPants sp = new ShortPants();
                        sp.Hue = 1108;
                        sp.LootType = LootType.Blessed;
                        AddItem( sp );

                        Shirt sh = new Shirt();
                        sh.Hue = 296;
                        sh.LootType = LootType.Blessed;
                        AddItem( sh );

                        HalfApron ha = new HalfApron();
                        ha.Hue = 296;
                        ha.LootType = LootType.Blessed;
                        AddItem( ha );

                        Shoes s = new Shoes();
                        s.Hue = 1108;
                        s.LootType = LootType.Blessed;
                        AddItem( s );

                         Item hair = new Item(8253);
                         hair.Hue = 1510;
                          hair.Layer = Layer.Hair;
                        hair.Movable = false;
                        AddItem(hair);

                        SkullCap sc = new SkullCap();
                        sc.Hue = 296;
                        sc.LootType = LootType.Blessed;
                        AddItem( sc );

                        LeatherGloves lg = new LeatherGloves();
                        lg.Hue = 1108;
                        lg.LootType = LootType.Blessed;
                        AddItem( lg );


                                                 
	       AddItem( new WarHammer() );
                       
           
 

		}

		public TheFishTankCrafter ( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from,List<ContextMenuEntry>list) 
	        { 
	                base.GetContextMenuEntries( from, list ); 
        	        list.Add( new TheFishTankCrafterEntry( from, this ) ); 
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

		public class TheFishTankCrafterEntry : ContextMenuEntry

		{
			private Mobile m_Mobile;
			private Mobile m_Giver;

            public TheFishTankCrafterEntry(Mobile from, Mobile giver)
                : base(6146, 3)
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
					if ( ! mobile.HasGump( typeof( FishTankCrafterGump ) ) )
					{
						mobile.SendGump( new FishTankCrafterGump( mobile ));
						mobile.AddToBackpack( new FishTankCrafterBasket() );
					} 
				}
			}
		}

		public override bool OnDragDrop( Mobile from, Item dropped )
		{          		
         	        Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
                        Account acct=(Account)from.Account;
			bool FullKegOfPaintRecieved = Convert.ToBoolean( acct.GetTag("FullKegOfPaintRecieved") );

			if ( mobile != null)
			{
				if( dropped is FullKegOfPaint )
            
         		{
         			if(dropped.Amount!=1)
         			{
					this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "please bring me that full keg of paint!", mobile.NetState );
         				return false;
         			}
                                if ( !FullKegOfPaintRecieved ) //added account tag check
		                {
					dropped.Delete(); 
					mobile.AddToBackpack( new  FishtankBoatAddonDeed() );
					mobile.SendMessage( "Thank you for your help!" );
                    acct.SetTag("FishtankBoatAddonDeed", "true");

				
         		        }
				else //what to do if account has already been tagged
         			{
         				mobile.SendMessage("You are so kind to have taken the time to help me obtain a full keg of paint.");
         				mobile.AddToBackpack( new Gold( 400 ) );
         				dropped.Delete();
         			}
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
