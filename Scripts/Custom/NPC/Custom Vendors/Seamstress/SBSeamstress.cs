// Made by RANCID77 aka EARL...
// I dont care if you use this as a base or modify it...
// Just plz leave this header.. thnx ...
using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBSeamstress : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSeamstress()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 18, 500, 4000, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingShears ), 20000, 20, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( BoltOfCloth ), 120, 20, 0xF95, 0 ) );
				Add( new GenericBuyInfo( typeof( Cotton ), 102, 200, 0xDF9, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( SpoolOfThread ), 9 );
				Add( typeof( SewingShears ), 10000 );
				Add( typeof( Cotton ), 51 );
				Add( typeof( BoltOfCloth ), 60 );
			}
		}
	}
}