using System.Collections.Generic;
using System.Linq;

namespace Server.OneTime.Events
{
    public static class OneTimeEventHelper
    {
		private static IEnumerable<Item> items;
		private static List<Item> itemList;

		private static IEnumerable<Mobile> mobiles;
		private static List<Mobile> mobileList;

		public static void SendIOneTime(int type)
        {
            items = from c in World.Items.Values
                                      where c is IOneTime
                                      select c as Item;

            itemList = new List<Item>(items);

			if (itemList.Count() > 0)
			{
				for (int i = 0; i < itemList.Count(); i++)
				{
					if (itemList[i] is IOneTime Iitem && itemList[i].Map != Map.Internal)
					{
						if (!itemList[i].Deleted)
							SendTick(Iitem, type);
					}
				}
			}

            mobiles = from c in World.Mobiles.Values
                                      where c is IOneTime
                                      select c as Mobile;

            mobileList = new List<Mobile>(mobiles);

			if (mobileList.Count() > 0)
			{
				for (int i = 0; i < mobileList.Count(); i++)
				{
					if (mobileList[i] is IOneTime Imobile && mobileList[i].Map != Map.Internal)
					{
						if (!mobileList[i].Deleted)
							SendTick(Imobile, type);
					}
				}
			}
        }

        private static void SendTick(IOneTime oneTime, int type)
        {
            if (oneTime.OneTimeType == type)
            {
                oneTime.OneTimeTick();
            }
        }
    }
}
