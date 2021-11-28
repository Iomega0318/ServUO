using System;
using System.Collections.Generic;
using Server.Items;
using Server.Engines.Quests;

namespace Server.Mobiles
{
    public class SBAlchemist : SBInfo
    {
        private readonly List<GenericBuyInfo> m_BuyInfo;
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBAlchemist(Mobile m)
        {
            if (m != null)
            {
                m_BuyInfo = new InternalBuyInfo(m);
            }
        }

        public override IShopSellInfo SellInfo
        {
            get
            {
                return m_SellInfo;
            }
        }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo(Mobile m)
            {                
                Add(new GenericBuyInfo(typeof(MortarPestle), 8, 10, 0xE9B, 0));
                Add(new GenericBuyInfo(typeof(ReagentHarvester), 17, 20, 0x26BB, 0));
                Add(new GenericBuyInfo(typeof(BlackPearl), 5, 20, 0xF7A, 0));
                Add(new GenericBuyInfo(typeof(Bloodmoss), 5, 20, 0xF7B, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 3, 20, 0xF84, 0));
                Add(new GenericBuyInfo(typeof(Ginseng), 3, 20, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 3, 20, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(Nightshade), 3, 20, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(SpidersSilk), 3, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 3, 20, 0xF8C, 0));

                Add(new GenericBuyInfo(typeof(Bottle), 5, 100, 0xF0E, 0, true)); 
                Add(new GenericBuyInfo(typeof(HeatingStand), 2, 100, 0x1849, 0));
                Add(new GenericBuyInfo(typeof(SkinTingeingTincture), 1255, 20, 0xEFF, 90));

                if (m.Map != Map.TerMur)
                {
                    Add(new GenericBuyInfo(typeof(HairDye), 37, 10, 0xEFF, 0));
                }
                else if (m is Zosilem)
                {
                    Add(new GenericBuyInfo(typeof(GlassblowingBook), 10637, 30, 0xFF4, 0));
                    Add(new GenericBuyInfo(typeof(SandMiningBook), 10637, 30, 0xFF4, 0));
                    Add(new GenericBuyInfo(typeof(Blowpipe), 21, 100, 0xE8A, 0x3B9));
                }
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                
            }
        }
    }
}
