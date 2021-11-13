//Scripted by Jumpnjahosofat
//This file is part of the Urshaabi Gauntlet System
//I do not take complete credit for all of the files.  Many are modified RunUO scripts.
//This system is intended for drop in purposes so that it's easy for everyone to enjoy it.
//If you encounter problems, please leave me a message on the forum or my email - uo_cecil@yahoo.com
//Enjoy!!

using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.CannedEvil
{	
	public class MiniChampionAltar : PentagramAddon
	{
		private MiniChamp m_Spawn;

		public MiniChampionAltar( MiniChamp spawn )
		{
			m_Spawn = spawn;
		}

		public override void OnAfterDelete()
		{
			base.OnAfterDelete();

			if ( m_Spawn != null )
				m_Spawn.Delete();
		}

		public MiniChampionAltar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( m_Spawn );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Spawn = reader.ReadItem() as MiniChamp;

					if ( m_Spawn == null )
						Delete();

					break;
				}
			}
		}
	}
}