using System;
using Server.Targeting;
using System.Collections.Generic;

namespace Server.Items
{
    public static class PlantHelper
    {
        #region Plants 
        public static int GetHarvests()
        {
            return Utility.RandomMinMax(8, 12);
        }

        public static DateTime GetDeathTime()
        {
            var lifespan = Utility.RandomMinMax(2400, 2880); //2400, 2880
            return DateTime.Now.AddMinutes(lifespan); //minutes
        }

        public class DeathTimer : Timer
        {
            private readonly Item m_Plant;
            public DeathTimer(Item plant, DateTime end) : base(end.Subtract(DateTime.Now))
            {
                m_Plant = plant;
                Priority = TimerPriority.OneMinute;
            }

            public DateTime GetDelay()
            {
                return this.Next;
            }

            protected override void OnTick()
            {
                if (m_Plant != null && !m_Plant.Deleted)
                {
                    m_Plant.Delete();
                }

                Stop();
            }

        }

        public static bool RangeCheck(BasePlant plant, Mobile from)
        {
            if (from.InRange(plant.Location, 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static HarvesterEquippedResult IsHarvesterEquipped(Mobile from)
        {
            if (from.FindItemOnLayer(Layer.OneHanded) is ReagentHarvester t)
            {
                return new HarvesterEquippedResult { Result = true, Tool = t };
            }
            else
            {
                return new HarvesterEquippedResult { Result = false, Tool = null };
            }
        }

        public class HarvesterEquippedResult
        {
            public bool Result;
            public BaseTool Tool;
        }

        public static void Harvest(BasePlant plant, Mobile from, BaseTool t)
        {
            t.UsesRemaining--;
            if (t.UsesRemaining == 0)
            {
                t.Delete();
                from.SendMessage("You have broken your reagent harvester.");
            }

            from.Freeze(TimeSpan.FromMilliseconds(1500));
            from.PlayAttackAnimation(AttackAnimation.Wrestle);

            from.CheckSkill(SkillName.Alchemy, 0.0, 80.0);

            //Failure
            if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 105.0))
            {
                from.SendMessage("You fail to collect the reagents and destroyed some in the process.");
                //Critical Fail
                if (.1 > Utility.RandomDouble())
                {
                    CriticalFail(plant, from);
                }                    
            }
            //Success
            else
            {
                AwardResource(plant, from);
                
                if (.1 > Utility.RandomDouble())
                {
                    AwardSeed(plant, from);
                }
                //80+ Alchemy Skill
                if (from.Skills[SkillName.Alchemy].Value >= 80.0)
                {
                    if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 105.0))
                    {
                        AwardResource(plant, from);

                        if (.1 > Utility.RandomDouble())
                        {
                            AwardSeed(plant, from);
                        }
                    }
                }
            }
        }

        private static void CriticalFail(BasePlant plant, Mobile from)
        {
            if (plant is MandrakePlant || plant is NightshadeBush)
            {
                from.ApplyPoison(from, Poison.Lesser);
                from.SendMessage("You cut yourself while harvesting.");
            }
        }

        private static void AwardResource(BasePlant plant, Mobile from)
        {
            if (plant is MandrakePlant) { from.AddToBackpack(new MandrakeRoot()); }
            else if (plant is NightshadeBush) { from.AddToBackpack(new Nightshade()); }

            from.SendMessage("You collect the reagents and put them in your pack.");
        }

        private static void AwardSeed(BasePlant plant, Mobile from)
        {
            if (plant is MandrakePlant) { from.AddToBackpack(new MandrakeSeed()); }
            else if (plant is NightshadeBush) { from.AddToBackpack(new NightshadeSeed()); }

            from.SendMessage("You collect a seed and put them in your pack.");
        }
        #endregion

        #region Seedlings       

        public static DateTime GetMatureTime()
        {
            var matures = Utility.RandomMinMax(360, 480); //360, 480
            return DateTime.Now.AddMinutes(matures); //minutes
        }

        public class MatureTimer : Timer
        {
            private readonly BaseSeedling m_Plant;
            public MatureTimer(BaseSeedling plant, DateTime end) : base(end.Subtract(DateTime.Now))
            {
                m_Plant = plant;
                Priority = TimerPriority.OneMinute;
            }

            public DateTime GetDelay()
            {
                return this.Next;
            }

            protected override void OnTick()
            {
                if (m_Plant != null && !m_Plant.Deleted)
                {
                    var location = m_Plant.Location;
                    var map = m_Plant.Map;

                    var maturePlant = PlantToGrow(m_Plant);
                    m_Plant.Delete();
                    maturePlant.MoveToWorld(location, map);
                }
                Stop();
            }

        }

        private static Item PlantToGrow(BaseSeedling plant)
        {
            if (plant is MandrakeSeedling) { return new MandrakePlant(plant.Planter); }
            else return new NightshadeBush(plant.Planter);
        }

        #endregion

        #region Seeds

        private static List<string> AllowedTerrain(BaseSeed seed)
        {
            if (seed is MandrakeSeed ||
                seed is NightshadeSeed)
            {
                return new List<string>() { "grass", "furrows", "forest", "jungle" };
            }
            else
            {
                return new List<string>() { "cave" };
            }
        }
            
        public static bool CanPlantHere(BaseSeed seed, Mobile from)
        {
            var tile = new LandTarget(from.Location, from.Map);
            if (!AllowedTerrain(seed).Contains(tile.Name))
            {
                from.SendMessage("You cannot plant here.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void PlantSeed(BaseSeed seed, Mobile from)
        {
            var seedling = GetSeedling(seed, from);
            from.Freeze(TimeSpan.FromMilliseconds(1500));
            from.PlayAttackAnimation(AttackAnimation.Wrestle);
            from.SendMessage("You plant the seed at your feet.");
            seed.Amount--;
            if (seed.Amount == 0)
            {
                seed.Delete();
            }

            seedling.MoveToWorld(from.Location, from.Map);
        }

        private static Item GetSeedling(BaseSeed seed, Mobile from)
        {
            if (seed is MandrakeSeed) { return new MandrakeSeedling(from); }
            else { return new NightshadeSeedling(from); }
        }

        #endregion
    }
}
