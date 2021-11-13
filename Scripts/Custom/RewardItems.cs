using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Network;

namespace ShardDelivery.Items
{
	public class ShardGift : Item
    {
        public static class Config
        {
            public static bool Enabled = true;                              // Item delivery enabled?
            public static int MinutesOnline = 60;                           // Gift delivery every X minutes.
            public static bool DropOnBank = true;                           // Gifts in Bankbox (true) or backpack (false)?
            public static AccessLevel MaxAccessLevel = AccessLevel.Player;  // This accesslevel and lower receives gifts.
        }
        public static void Initialize()
        {
            if (Config.Enabled)
                new ShardGiftAutoDistributionTimer().Start();
        }

        public ShardGift(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            reader.ReadInt();
        }
        class ShardGiftAutoDistributionTimer : Timer
        {
            public ShardGiftAutoDistributionTimer() : base(TimeSpan.Zero, TimeSpan.FromMinutes(Config.MinutesOnline))
            {
                Priority = TimerPriority.OneMinute;
            }
            protected override void OnTick()
            {
                foreach (NetState state in NetState.Instances)
                {
                    PlayerMobile m = state.Mobile as PlayerMobile;

                    if (m != null && m.AccessLevel <= Config.MaxAccessLevel)
                    {
                        if (Config.DropOnBank && m.BankBox != null)
                        {
                            Item rs = m.BankBox.FindItemByType(typeof(RewardItem));

                            if (rs != null)
                            {
                                rs.Amount++;
                            }
                            else
                            {
                                m.BankBox.DropItem(new RewardItem());
                            }
                        }
                        else if (m.Backpack != null)
                        {
                            Item rs = m.Backpack.FindItemByType(typeof(RewardItem));

                            if (rs != null)
                            {
                                rs.Amount++;
                            }
                            else
                            {
                                m.Backpack.DropItem(new RewardItem());
                            }
                        }
                    }
                }
            }
        }
    }
}
	
namespace Server.Items
{
	public abstract class BaseRewardItem : Item	
	{
		public override double DefaultWeight
		{
			get { return 0.0; }
		}
		public BaseRewardItem() : base( 0x3195 )
		{
		}
		public BaseRewardItem( int amount ) : base( 0x3195 )
		{
			Name = "Reward Tokens";
			Hue = 165;
			Stackable = true;
			Amount = amount;
			LootType = LootType.Blessed;
		}
		public BaseRewardItem( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty(ObjectPropertyList list)
        {
            if (this.Amount > 1)
                list.Add(String.Format("{0} Reward Tokens", this.Amount));
            else
                list.Add("a Reward Token");
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

	public class RewardItemDeed : Item 
	{
		private int m_Worth;
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Worth
		{
			get{ return m_Worth; }
			set{ m_Worth = value; InvalidateProperties(); }
		}
		public RewardItemDeed( Serial serial ) : base( serial ) 
		{ 
		} 
		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_Worth );			
		} 
		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
				{
					m_Worth = reader.ReadInt();
					break;
				}
			}
		}
		[Constructable]
		public RewardItemDeed( int worth) : base (5360)
		{
			Movable = true;
			Hue = 1165;
			Name = "a Reward Item Deed";
			m_Worth = worth;
		}
		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			string worth;
			worth = m_Worth.ToString();

			list.Add( 1060738, worth ); // value: ~1_val~
		}
		public override void OnDoubleClick( Mobile from )
		{
			Container pack = from.Backpack;

			int amounts = 0;
			int toAdd = m_Worth;
			RewardItem rewarditem;

			if ( toAdd > 0 )
			{
				rewarditem = new RewardItem(); //( toAdd );
				rewarditem.Amount = toAdd;

				if ( pack.TryDropItem( from, rewarditem, false ) )
				{
					amounts += toAdd;
					this.Delete();
				}
				else
				{
					this.Delete();

					from.AddToBackpack( new RewardItemDeed( toAdd ) );
				}
			}
		}
	} 
	
	public class RewardItem : BaseRewardItem
	{
		[Constructable]
		public RewardItem() : this( 1 )
		{
		}

		[Constructable]
		public RewardItem( int amountFrom, int amountTo ) : this( Utility.RandomMinMax( amountFrom, amountTo ) )
		{
		}

		[Constructable]
		public RewardItem( int amount ) : base()
		{
			Name = "Reward Token";
			Hue = 165;
			Stackable = true;
			Amount = amount;
			LootType = LootType.Blessed;
		}
		public RewardItem( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperty(ObjectPropertyList list)
        {
            if (this.Amount > 1)
                list.Add(String.Format("{0} Reward Tokens", this.Amount));
            else
                list.Add("a Reward Token");
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