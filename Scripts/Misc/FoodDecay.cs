using System;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Misc
{
    public class FoodDecayTimer : Timer
    {
        public FoodDecayTimer()
            : base(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5)) //TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5)
        {
            this.Priority = TimerPriority.OneMinute;
        }

        public static void Initialize()
        {
            new FoodDecayTimer().Start();
        }

        public static void FoodDecay()
        {
            foreach (NetState state in NetState.Instances)
            {
                if (state.Mobile is PlayerMobile m)
                {                    
                    PlayerHungerDecay(m);
                }
                else
                {
                    HungerDecay(state.Mobile);                    
                }
                ThirstDecay(state.Mobile);
            }
        }

        public static void PlayerHungerDecay(PlayerMobile m)
        {
            if (m.StomachContents == null)
            {
                m.StomachContents = new List<StomachContentsEntry>();
            }

            if (m.Hunger == 1)
            {
                m.Hunger = 0;
                m.StomachContents.Clear();
                NIWHunger.ApplyStarvation(m);
                NIWHunger.CalculateHunger(m);
                return;
            }

            if (m.Hunger == 0)
            {
                return;
            }

            m.StomachContents[0].FillFactor -= 1;
            if (m.StomachContents[0].FillFactor == 0)
            {
                m.RemoveStatMod("food");
                m.StomachContents.RemoveAt(0);
                NIWHunger.ApplyFoodBuff(m, m.StomachContents[0].Stat, m.StomachContents[0].Intensity);
            }
            m.Hunger = NIWHunger.CalculateHunger(m);
        }

        public static void HungerDecay(Mobile m)
        {
            if (m != null && m.Hunger >= 1)
                m.Hunger -= 1;
        }

        public static void ThirstDecay(Mobile m)
        {
            if (m != null && m.Thirst >= 1)
                m.Thirst -= 1;
        }

        protected override void OnTick()
        {
            FoodDecay();			
        }
    }
}
