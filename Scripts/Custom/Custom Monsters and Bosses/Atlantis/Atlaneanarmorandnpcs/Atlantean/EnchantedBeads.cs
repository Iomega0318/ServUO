using System;
using Server.Network;
using Server.Prompts;
using Server.Items;
using Server.Targeting;
using Server;

namespace Server.Items
{
	public class EnchantedBeadTarget : Target
	{
		private EnchantedBeads m_Beads;

		public EnchantedBeadTarget( EnchantedBeads beads ) : base( 1, false, TargetFlags.None )
		{
			m_Beads = beads;
		}

		protected override void OnTarget( Mobile from, object target )
		{
			if ( target is EnchantedSeaRoseStatuette )
			{
				Item item = (Item)target;
				if ( ((EnchantedSeaRoseStatuette)item).UsesRemaining >= 5 )
				{
					from.SendMessage( "This item is fully charged, and will not accept the beads.");
				}
					
				else
				{	
					if( item.RootParent != from ) 
					{
						from.SendMessage( "This must be in your backpack to use it." );
					}
					else
					{
						((EnchantedSeaRoseStatuette)item).UsesRemaining += 1;
						from.SendMessage( "The beads bond their powers to the statue." );

						m_Beads.Delete(); 
					}
				}
			}
						
			else if ( target is SerpentsMedallion )
			{
				Item item = (Item)target;
				if ( ((SerpentsMedallion)item).UsesRemaining >= 5 )
				{
					from.SendMessage( "This item is fully charged, and will not accept the beads.");
				}
					
				else
				{	
					if( item.RootParent != from )
					{
						from.SendMessage( "This must be in your backpack to use it." );
					}
					else
					{
						((SerpentsMedallion)item).UsesRemaining += 1;
						from.SendMessage( "The beads bond their powers to the medallion." );

						m_Beads.Delete(); 
					}
				}
			}
			else
			{
			from.SendMessage( "You cannot use the beads on that item." );
			}
		}
	}
	
	public class EnchantedBeads : Item
	{
		[Constructable]
		public EnchantedBeads() : base( 0x108B )
		{
			Name = "a string of enchanted beads";
			Weight = 1.0;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				
			{
				from.SendMessage( "This must be in your backpack to use it." );
			}
			else
			{
				from.Target = new EnchantedBeadTarget( this );
				from.SendMessage( "Target an item to enchant." );
			}
		}

		public EnchantedBeads( Serial serial ) : base( serial )
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

