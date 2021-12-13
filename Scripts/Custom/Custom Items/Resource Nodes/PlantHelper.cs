using System;
using Server.Targeting;
using Server.Mobiles;
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
            return DateTime.UtcNow.AddMinutes(lifespan); //minutes
        }

        public class DeathTimer : Timer
        {
            private readonly Item m_Plant;
            public DeathTimer(Item plant, DateTime end) : base(end.Subtract(DateTime.UtcNow))
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
            if (plant is MandrakePlant ||
                plant is NightshadeBush ||
                plant is BloodmossInfestation)
            {
                from.ApplyPoison(from, Poison.Lesser);
                from.SendMessage("You cut yourself while harvesting.");
            }
            else if (plant is GarlicPlant ||
                plant is GinsengPlant ||
                plant is BlackPearlPlant)
            {
                from.SendMessage("You disturb a rats nest while harvesting.");
                var tiles = plant.GetAllPointsInRange(from.Map, 1);
                foreach (Point3D tile in tiles)
                {
                    var t = new LandTarget(tile, from.Map);
                    if (t.Flags != TileFlag.Impassable || !t.IsWater())
                    {
                        if (.25 > Utility.RandomDouble())
                        {
                            Mobile rat = new Sewerrat();
                            if (.25 > Utility.RandomDouble())
                            {
                                rat = new GiantRat();
                            }
                            rat.MoveToWorld(tile, plant.Map);
                        }
                    }
                }                
            }
            else if (plant is SpiderNest)
            {
                from.SendMessage("You disturb the spiders.");
                var tiles = plant.GetAllPointsInRange(from.Map, 1);
                foreach (Point3D tile in tiles)
                {
                    var t = new LandTarget(tile, from.Map);
                    if (t.Flags != TileFlag.Impassable || !t.IsWater())
                    {
                        if (.25 > Utility.RandomDouble())
                        {
                            Mobile spider = new TrapdoorSpider();
                            if (.25 > Utility.RandomDouble())
                            {
                                spider = new GiantSpider();
                            }
                            spider.MoveToWorld(tile, plant.Map);
                        }
                    }
                }
            }
            else if (plant is SulferousAshPile)
            {
                from.SendMessage("You burn yourself while harvesting.");
                from.Damage(25);                
                from.PlayDamagedAnimation();
                from.PlayHurtSound();
            }
        }

        private static void AwardResource(BasePlant plant, Mobile from)
        {
            if (plant is MandrakePlant) { from.AddToBackpack(new MandrakeRoot()); }
            else if (plant is GarlicPlant) { from.AddToBackpack(new Garlic()); }
            else if (plant is GinsengPlant) { from.AddToBackpack(new Ginseng()); }
            else if (plant is SpiderNest) { from.AddToBackpack(new SpidersSilk()); }
            else if (plant is BloodmossInfestation) { from.AddToBackpack(new Bloodmoss()); }
            else if (plant is BlackPearlPlant) { from.AddToBackpack(new BlackPearl()); }
            else if (plant is SulferousAshPile) { from.AddToBackpack(new SulfurousAsh()); }
            else if (plant is NightshadeBush) { from.AddToBackpack(new Nightshade()); }

            from.SendMessage("You collect the reagents and put them in your pack.");
        }

        private static void AwardSeed(BasePlant plant, Mobile from)
        {
            if (plant is MandrakePlant) { from.AddToBackpack(new MandrakeSeed()); }
            else if (plant is GarlicPlant) { from.AddToBackpack(new GarlicSeed()); }
            else if (plant is GinsengPlant) { from.AddToBackpack(new GinsengSeed()); }            
            else if (plant is BloodmossInfestation) { from.AddToBackpack(new BloodmossSpores()); }
            else if (plant is BlackPearlPlant) { from.AddToBackpack(new BlackPearlSeed()); }
            else if (plant is NightshadeBush) { from.AddToBackpack(new NightshadeSeed()); }
            else if (plant is SpiderNest)
            {
                from.AddToBackpack(new ClusterOfSpiders());
                from.SendMessage("You collect some spiders and put them in your pack.");
                return;
            }
            else if (plant is SulferousAshPile)
            {
                from.AddToBackpack(new Sulfur());
                from.SendMessage("You collect some sulfur and put them in your pack.");
                return;
            }

            from.SendMessage("You collect a seed and put them in your pack.");
        }
        #endregion

        #region Seedlings       

        public static DateTime GetMatureTime()
        {
            var matures = Utility.RandomMinMax(30, 30); //360, 480
            return DateTime.UtcNow.AddSeconds(matures); //minutes
        }

        public class MatureTimer : Timer
        {
            private readonly BaseSeedling m_Plant;
            public MatureTimer(BaseSeedling plant, DateTime end) : base(end.Subtract(DateTime.UtcNow))
            {
                m_Plant = plant;
                Priority = TimerPriority.OneSecond;
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
            else if (plant is GarlicSeedling) { return new GarlicPlant(plant.Planter); }
            else if (plant is GinsengSeedling) { return new GinsengPlant(plant.Planter); }
            else if (plant is BloodmossClump) { return new BloodmossInfestation(plant.Planter); }
            else if (plant is BlackPearlSeedling) { return new BlackPearlPlant(plant.Planter); }
            else if (plant is SmallSpiderNest) { return new SpiderNest(plant.Planter); }
            else if (plant is BurningSulfur) { return new SulferousAshPile(plant.Planter); }
            else return new NightshadeBush(plant.Planter);
        }

        #endregion

        #region Seeds

        private static List<string> AllowedTerrain(BaseSeed seed)
        {
            return new List<string>() { "grass", "furrows", "forest", "jungle" };
        }
            
        public static bool CanPlantHere(BaseSeed seed, Mobile from)
        {
            var tile = new LandTarget(from.Location, from.Map);
            if (!AllowedTerrain(seed).Contains(tile.Name))
            {
                if (seed is ClusterOfSpiders)
                {
                    from.SendMessage("You feel the spiders could not survive here.");
                }
                if (seed is Sulfur)
                {
                    from.SendMessage("You cannot burn sulfur here.");
                }
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
            
            seed.Amount--;
            if (seed.Amount == 0)
            {
                seed.Delete();
            }

            seedling.MoveToWorld(from.Location, from.Map);
            if (seed is ClusterOfSpiders)
            {
                from.SendMessage("You place the spiders where they are sure to not be disturbed.");
                return;
            }
            if (seed is Sulfur)
            {
                from.SendMessage("You ignite the sulfur.");
                return;
            }
            from.SendMessage("You plant the seed at your feet.");
        }

        private static Item GetSeedling(BaseSeed seed, Mobile from)
        {
            if (seed is MandrakeSeed) { return new MandrakeSeedling(from); }
            else if (seed is GarlicSeed) { return new GarlicSeedling(from); }
            else if (seed is GinsengSeed) { return new GinsengSeedling(from); }
            else if (seed is BloodmossSpores) { return new BloodmossClump(from); }
            else if (seed is ClusterOfSpiders) { return new SmallSpiderNest(from); }
            else if (seed is Sulfur) { return new BurningSulfur(from); }
            else if (seed is BlackPearlSeed) { return new BlackPearlSeedling(from); }
            else { return new NightshadeSeedling(from); }
        }

        #endregion
    }
}
