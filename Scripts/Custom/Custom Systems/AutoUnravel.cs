using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server.SkillHandlers
{
    class AutoUnravel
    {
        public static Item Unravel(Item item)
        {
            int weight = Imbuing.GetTotalWeight(item, -1, false, true);

            if (weight <= 0)
            {
                return item;
            }
            if (weight > 550)
            {
                return item;
            }
            if (weight >= 400)
            {
                return new RelicFragment();
            }
            if (weight > 200)
            {
                return new EnchantedEssence();
            }
            else
            {
                return new MagicalResidue();
            }
        }
    }
}
