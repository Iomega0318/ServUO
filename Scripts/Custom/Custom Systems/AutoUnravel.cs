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
                if (item is IDurability d)
                {
                    //d.CanFortify = false;
                    if (d.MaxHitPoints > 50)
                    {
                        d.MaxHitPoints = 50;
                        d.HitPoints = 50;
                    }
                }
                item.LootType = LootType.Cursed;
                return item;
            }
            if (weight >= 400)
            {
                item.Delete();
                return new RelicFragment();
            }
            if (weight > 200)
            {
                item.Delete();
                return new EnchantedEssence();
            }
            else
            {
                item.Delete();
                return new MagicalResidue();
            }
        }
    }
}
