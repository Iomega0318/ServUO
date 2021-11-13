using System;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Spells;

namespace Server.Items
{
	public class EnchantedSeaRoseStatuette : Item
	{
		private int m_UsesRemaining;

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; InvalidateProperties(); }
		}

		[Constructable]
		public EnchantedSeaRoseStatuette() : base( 6377 )
		{
			Weight = 1.0;
			LootType = LootType.Regular;
			Name = "a enchanted sea rose statuette";
			Hue = 1159;
			UsesRemaining = 1;
		}

		public EnchantedSeaRoseStatuette( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			if (m_UsesRemaining >= 1)
			{
				SpellHelper.AddStatBonus( from, from, StatType.Int, 10, TimeSpan.FromMinutes( 10 ));
				m_UsesRemaining = m_UsesRemaining -1;
			}
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			list.Add( 1060584, m_UsesRemaining.ToString() );
		}
	}
}
