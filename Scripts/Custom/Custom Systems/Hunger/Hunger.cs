using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Items;
using Server.Spells;

namespace Server.Services
{
    public class Hunger
    {
        private Mobile m_Player;
        private List<Food> m_FoodEaten;
        private bool m_Starving;
        private TimeSpan m_TimeUntilStarving;
        private TimeSpan m_CurrentFoodDigesttionTime;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Starving
        {
            get
            {
                return m_Starving;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TimeSpan TimeUntilStarving
        {
            get
            {
                return m_TimeUntilStarving;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TimeSpan CurrentFoodDigesttionTime
        {
            get
            {
                return m_CurrentFoodDigesttionTime;
            }
        }

        public Hunger(Mobile from)
        {
            m_Player = from;
            m_FoodEaten = new List<Food>();
            //Eat(new FishSteak());
        }

        public Hunger(Serial serial)
        {
        }

        public void Vomit()
        {
            m_FoodEaten.Clear();
            Starve();
        }

        public void Digest(Food food)
        {
            foreach (FoodEffect effect in food.Buffs)
            {
                //m_Player.AddStatMod(new Statmod(effect.Stat, "Food", effect.Offset, new TimeSpan(0, food.MinutesToDigest, 0)));
            }
        }

        public void Starve()
        {            
            if(m_FoodEaten.Count <= 0)
            {
                m_Starving = true;
                m_Player.AddStatMod(new StatMod(StatType.All, "Starvation", -10, TimeSpan.Zero));
                m_Player.SendMessage("You are starving!");
            }
            else 
            {
                m_Player.RemoveStatMod("Starvation");
                m_Player.SendMessage("You are starving!");
            }
        }
    }

    public class FoodEffect
    {
        public StatType Stat { get; set; }
        public int Offset { get; set; }

        public FoodEffect(StatType stat, int offset)
        {
            Stat = stat;
            Offset = offset;
        }
    }
}
