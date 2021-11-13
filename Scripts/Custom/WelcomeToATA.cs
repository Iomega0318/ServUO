////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///**************************************************************************************************************///
///*AEOLUS'S CUSTOM SCRIPT PACKAGE V1.0.0									*///
///*Aeolus's Custom GeneralVorKath.cs V1.0.0									*///
///*Based on RunUO V1.0.0 Distro Healer.cs									*///
///*Summary: Sells AdvancedDemonologyBook, and buys BloodBlades. Also talks about Narsynnolyxx & the Shadow	*///
///*	Sentinels.												*///
///*aeolusflux@yahoo.com											*///
///**************************************************************************************************************///
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "the remains of Welcome To ATA" )]
    public class WelcomeToATA : BaseCreature
	{
		//private ArrayList m_SBInfos = new ArrayList();
		//protected override ArrayList SBInfos{ get { return m_SBInfos; } }

		private DateTime m_NextTalk;
		private string m_name;
		public DateTime NextTalk{ get{ return m_NextTalk; } set{ m_NextTalk = value; } }
   
		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if(!m.Hidden && m is PlayerMobile)
			{
				if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) )
				{
					m_name = m.Name;
					switch ( Utility.Random( 4 ))
					{
                        case 0: Say("Welcome To Adjournment To Antiquity!," + m_name + ""); break;
						case 1: Say( "Dare To Journey And Discover ATA." ); break;
						case 2: Say( "Your Game Client, " + m_name + "... Should Be At Least 7.0.3.0" ); break;
                        case 3: Say( "You may return to the start room at any time, " + m_name + "" ); break;
					};
					m_NextTalk = (DateTime.Now + TimeSpan.FromSeconds( 2 ));
				}
			}
		}

		[Constructable]
		public WelcomeToATA() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)  
		{
			Name = "Welcome To ATA";
            SpeechHue = Utility.RandomDyedHue();
			Hue = 0x83F3;
			Body = 0x190;
          //if ( IsInvulnerable && !Core.AOS )
				NameHue = 0x34;

            SetStr(125, 130);
            SetDex(150, 160);
            SetInt(120, 125);
		
        
		
		
    
		
	    Item hair = new Item( 8253 ); 
	    hair.Hue = 1154; 
	    hair.Layer = Layer.Hair; 
	    hair.Movable = false; 
	    AddItem( hair );
			

		 Item LongPants = new Item( 5422 );
	    LongPants.Hue = 1109;
	    LongPants.Layer = Layer.Pants;
	    LongPants.LootType = LootType.Blessed;
	    AddItem( LongPants );

            Item FancyShirt = new Item( 7933 );
	    FancyShirt.Hue = 1154;
	    FancyShirt.Layer = Layer.Shirt;
	    FancyShirt.LootType = LootType.Blessed;
	    AddItem( FancyShirt );

            Item Doublet = new Item( 8059 );
	    Doublet.Hue = 1109;
	    Doublet.Layer = Layer.MiddleTorso;
	    Doublet.LootType = LootType.Blessed;
	    AddItem( Doublet );
			
			
			
		}

		public override bool ClickTitle{ get{ return false; } }

        public WelcomeToATA(Serial serial)
            : base(serial)
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
