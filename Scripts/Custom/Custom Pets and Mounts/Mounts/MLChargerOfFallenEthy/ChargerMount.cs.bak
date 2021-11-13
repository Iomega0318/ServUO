/////Edited By Erica/////

using System;
using Server.Mobiles;
using Server.Items;
using Server.Spells;
using Server.Engines.VeteranRewards;

namespace Server.Mobiles
{
	public class ChargerMount : Item, IMount, IMountItem, Engines.VeteranRewards.IRewardItem
	{
		private int m_MountedID;
		private int m_RegularID;
		private Mobile m_Rider;
		private bool m_IsRewardItem;

		[CommandProperty( AccessLevel.GameMaster )]
		public bool IsRewardItem
		{
			get{ return m_IsRewardItem; }
			set{ m_IsRewardItem = value; }
		}

		[Constructable]
		public ChargerMount( int itemID, int mountID ) : base( itemID )
		{
			m_MountedID = mountID;
			m_RegularID = itemID;
			m_Rider = null;

			Layer = Layer.Invalid;

			LootType = LootType.Blessed;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int MountedID
		{
			get
			{
				return m_MountedID;
			}
			set
			{
				if ( m_MountedID != value )
				{
					m_MountedID = value;

					if ( m_Rider != null )
						ItemID = value;
				}
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int RegularID
		{
			get
			{
				return m_RegularID;
			}
			set
			{
				if ( m_RegularID != value )
				{
					m_RegularID = value;

					if ( m_Rider == null )
						ItemID = value;
				}
			}
		}

		public ChargerMount( Serial serial ) : base( serial )
		{
		}

		public override bool DisplayLootType{ get{ return true; } }
//public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }
		public virtual int FollowerSlots{ get{ return 1; } }

		public void RemoveFollowers()
		{
			if ( m_Rider != null )
				m_Rider.Followers -= FollowerSlots;

			if ( m_Rider != null && m_Rider.Followers < 0 )
				m_Rider.Followers = 0;
		}

		public void AddFollowers()
		{
			if ( m_Rider != null )
				m_Rider.Followers += FollowerSlots;
		}
            public virtual void OnRiderDamaged( int amount, Mobile from, bool willKill )
		{
			
            }
		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			else if ( m_IsRewardItem && !Engines.VeteranRewards.RewardSystem.CheckIsUsableBy( from, this, null ) )
				return;
			else if ( !from.CanBeginAction( typeof( BaseMount ) ) )
				from.SendLocalizedMessage( 1040024 ); // You are still too dazed from being knocked off your mount to ride!
			else if ( from.Mounted )
				from.SendLocalizedMessage( 1005583 ); // Please dismount first.
			else if ( from.IsBodyMod && !from.Body.IsHuman )
				from.SendLocalizedMessage( 1061628 ); // You can't do that while polymorphed.
			else if ( from.HasTrade )
				from.SendLocalizedMessage( 1042317, "", 0x41 ); // You may not ride at this time
			else if ( (from.Followers + FollowerSlots) > from.FollowersMax )
				from.SendLocalizedMessage( 1049679 ); // You have too many followers to summon your mount.
			else if ( Multis.DesignContext.Check( from ) )
				new ChargerSpell( this, from ).Cast();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 2 ); // version

			writer.Write( (bool) m_IsRewardItem );

			writer.Write( (int)m_MountedID );
			writer.Write( (int)m_RegularID );
			writer.Write( m_Rider );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			LootType = LootType.Blessed;

			int version = reader.ReadInt();

			switch ( version )
			{
				case 2:
				{
					m_IsRewardItem = reader.ReadBool();
					goto case 0;
				}
				case 1: reader.ReadInt(); goto case 0;
				case 0:
				{
					m_MountedID = reader.ReadInt();
					m_RegularID = reader.ReadInt();
					m_Rider = reader.ReadMobile();

					if ( m_MountedID == 0x3EA2 )
						m_MountedID = 0x3EAA;

					break;
				}
			}

			AddFollowers();
		}

		public override DeathMoveResult OnParentDeath( Mobile parent )
		{
			Rider = null;//get off, move to pack

			return DeathMoveResult.RemainEquiped;
		}

		public static void Dismount( Mobile m )
		{
			IMount mount = m.Mount;

			if ( mount != null )
				mount.Rider = null;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public Mobile Rider
		{
			get
			{
				return m_Rider;
			}
			set
			{
				if ( value != m_Rider )
				{
					if ( value == null )
					{
						Internalize();
						UnmountMe();

						RemoveFollowers();
						m_Rider = value;
					}
					else
					{
						if ( m_Rider != null )
							Dismount( m_Rider );

						Dismount( value );

						RemoveFollowers();
						m_Rider = value;
						AddFollowers();

						MountMe();
					}
				}
			}
		}

		public void UnmountMe()
		{
			Container bp = m_Rider.Backpack;

			ItemID = m_RegularID;
			Layer = Layer.Invalid;
			Movable = true;

			if ( bp != null )
			{
				bp.DropItem( this );
			}
			else
			{
				Point3D loc = m_Rider.Location;
				Map map = m_Rider.Map;

				if ( map == null || map == Map.Internal )
				{
					loc = m_Rider.LogoutLocation;
					map = m_Rider.LogoutMap;
				}

				MoveToWorld( loc, map );
			}
		}

		public void MountMe()
		{
			ItemID = m_MountedID;
			Layer = Layer.Mount;
			Movable = false;

			ProcessDelta();
			m_Rider.ProcessDelta();
			m_Rider.EquipItem( this );
			m_Rider.ProcessDelta();
			ProcessDelta();
		}

		public IMount Mount
		{
			get
			{
				return this;
			}
		}

		public static void StopMounting( Mobile mob )
		{
			if ( mob.Spell is ChargerSpell )
				((ChargerSpell)mob.Spell).Stop();
		}

		private class ChargerSpell : Spell
		{
			private static SpellInfo m_Info = new SpellInfo( "Charger Mount", "", /*SpellCircle.Second,*/ 230 );

			private ChargerMount m_Mount;
			private Mobile m_Rider;

			public ChargerSpell( ChargerMount mount, Mobile rider ) : base( rider, null, m_Info )
			{
				m_Rider = rider;
				m_Mount = mount;
			}

			public override bool ClearHandsOnCast{ get{ return false; } }
			public override bool RevealOnCast{ get{ return false; } }
public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds( 1.0 ); } }
			public override TimeSpan GetCastRecovery()
			{
				return TimeSpan.Zero;
			}

			public override TimeSpan GetCastDelay()
			{
				return TimeSpan.FromSeconds( 0.0 );
			}

			public override int GetMana()
			{
				return 0;
			}

			public override bool ConsumeReagents()
			{
				return true;
			}

			public override bool CheckFizzle()
			{
				return true;
			}

			private bool m_Stop;

			public void Stop()
			{
				m_Stop = true;
				Disturb( DisturbType.Hurt, false, false );
			}

			public override bool CheckDisturb( DisturbType type, bool checkFirst, bool resistable )
			{
				if ( type == DisturbType.EquipRequest || type == DisturbType.UseRequest/* || type == DisturbType.Hurt*/ )
					return false;

				return true;
			}

			public override void DoHurtFizzle()
			{
				if ( !m_Stop )
					base.DoHurtFizzle();
			}

			public override void DoFizzle()
			{
				if ( !m_Stop )
					base.DoFizzle();
			}

			public override void OnDisturb( DisturbType type, bool message )
			{
				if ( message && !m_Stop )
					Caster.SendLocalizedMessage( 1049455 ); // You have been disrupted while attempting to summon your ethereal mount!

				//m_Mount.UnmountMe();
			}

			public override void OnCast()
			{
				if ( !m_Mount.Deleted && m_Mount.Rider == null && m_Mount.IsChildOf( m_Rider.Backpack ) )
					m_Mount.Rider = m_Rider;

				FinishSequence();
			}
		}
	}

	public class ChargeroftheFallen : ChargerMount
	{
		public override int LabelNumber{ get{ return 1074816; } } // Ethereal Horse Statuette

		[Constructable]
		public ChargeroftheFallen() : base( 11676, 0x3E92 )
		{
		}

		public ChargeroftheFallen( Serial serial ) : base( serial )
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
