using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class SerpentsMedallion : GoldNecklace
	{
		public int m_UsesRemaining;
		//private RemoveTimer m_Timer;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}
		
		public override int ArtifactRarity{ get{ return 30; } }

		[Constructable]
		public SerpentsMedallion()
		{
			Name = "Serpents Medallion";
			Hue = 2823;
			
			Attributes.BonusMana = 8;
			Attributes.CastRecovery = 1;
             Attributes.CastSpeed = 1;
              Attributes.LowerManaCost = 10;
              Attributes.LowerRegCost = 15;
			
			Resistances.Cold = 25;
			m_UsesRemaining = 20;
		}
		
		public override bool OnEquip( Mobile m )
		{
			if( m is PlayerMobile )
			{
				if( m_UsesRemaining >= 1 )
				{
					if( m.BodyValue == 400 || m.BodyValue == 401 )
					{
						m.SendMessage( "You begin to get an awkward sensation, as the medallion emits a brilliant glowing light." );
						m.BodyMod = 150;
						m_UsesRemaining = m_UsesRemaining -1;
						return true;
					}
					else
					{
						m.SendMessage( "The medallion notices your form as unhuman, and rejects you." );
						return false;
					}
				}
				else if( m_UsesRemaining < 1 )
				{
					m.SendMessage( "This necklace has lost its enchantment, and will not let you wear it." );
					return false;
				}
			}
			return true;
		}
		
		public override void OnRemoved( object parent )
		{
			if( parent is PlayerMobile )
			{
				Mobile m = (Mobile)parent;
				
				m.SendMessage( "You remove the necklace, lifting the enchantment." );
				m.BodyMod = 0;
			}
		}
		
		/*private class RemoveTimer : Timer
		{
			private SerpentsMedallion m_Item;
			
			public RemoveTimer( SerpentsMedallion item ) : base( TimeSpan.FromMinutes( 30 ) )
			{
				Priority = TimerPriority.FiftyMS;
				m_Item = item;
			}
			
			protected override void OnTick()
			{
				.RemoveItem( item ); //Here's the problem. Not sure how to reference the playermobile wearing the item...
			}
		}*/
		
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060584, m_UsesRemaining.ToString() );
		}

		public SerpentsMedallion( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( m_UsesRemaining );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 0:
				{
					m_UsesRemaining = reader.ReadInt();
					break;
				}
			}
		}
	}
}
