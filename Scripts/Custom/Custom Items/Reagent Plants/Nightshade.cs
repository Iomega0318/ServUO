using System;
using System.Threading.Tasks;
using System.Timers;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Targeting;
using Server.Engines.Craft;
using System.Threading;
using CustomsFramework;

namespace Server.Items
{
    public class NightshadeBush : Item
    {
        private int m_Harvests;
        private DateTime m_LastHarvested;
        private InternalTimer m_DeathTimer;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Harvests
        {
            get { return m_Harvests; }
            set { m_Harvests = value; }
        }        

        [Constructable]
        public NightshadeBush()
            :base(0x0DEE)
        {
            Name = "Nightshade Bush";
            Movable = false;
            Hue = 0x23C;

            m_Harvests = Utility.RandomMinMax(8, 12);
            m_LastHarvested = DateTime.Now;

            var lifespan = Utility.RandomMinMax(2400, 2880);
            var end = DateTime.Now.AddMinutes(lifespan);
            m_DeathTimer = new InternalTimer(this, end);
            m_DeathTimer.Start();
        }

        public NightshadeBush(Serial serial)
            : base(serial)
        {
        }

        protected class InternalTimer : Timer
        {
            private readonly NightshadeBush m_Bush;
            public InternalTimer(NightshadeBush bush, DateTime end) : base(end.Subtract(DateTime.Now))
            {
                m_Bush = bush;
                Priority = TimerPriority.OneMinute;
            }

            public DateTime GetDelay()
            {
                return this.Next;
            }

            protected override void OnTick()
            {
                if (m_Bush != null && !m_Bush.Deleted)
                {
                    m_Bush.Delete();
                }

                Stop();
            }

        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (from.InRange(Location, 1))
            {
                if(from.FindItemOnLayer(Layer.OneHanded) is ReagentHarvester t )
                {
                    if (DateTime.Now < m_LastHarvested.AddMilliseconds(1500))
                    {
                        from.SendLocalizedMessage(500119); // You must wait to perform another action.
                        return;
                    }

                    if (from.Mounted)
                    {
                        from.SendMessage("You cannot harvest reagents while mounted.");
                        return;
                    }

                    t.UsesRemaining--;
                    if (t.UsesRemaining == 0)
                    {
                        t.Delete();
                        from.SendMessage("You have broken your reagent harvester.");
                    }
                    from.Freeze(TimeSpan.FromMilliseconds(1500));
                    from.PlayAttackAnimation(AttackAnimation.Wrestle);
                    m_LastHarvested = DateTime.Now;
                    Harvests--;
                    if (Harvests <= 0)
                    {
                        Delete();
                    }

                    from.CheckSkill(SkillName.Alchemy, 0.0, 80.0);

                    if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 100.0))
                    {
                        from.SendMessage("You fail to collect the reagents and destroyed some in the process.");
                        if (.1 > Utility.RandomDouble())
                        {
                            from.ApplyPoison(from, Poison.Lesser);
                            from.SendMessage("You cut yourself while harvesting.");
                        }
                    }
                    else
                    {
                        from.AddToBackpack(new Nightshade());
                        from.SendMessage("You collect the reagents and put them in your pack.");
                        if (.1 > Utility.RandomDouble())
                        {
                            from.AddToBackpack(new NightshadeSeed());

                        }

                        if (from.Skills[SkillName.Alchemy].Value >= 80.0)
                        {
                            if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 100.0))
                            {
                                if (.1 > Utility.RandomDouble())
                                {
                                    from.AddToBackpack(new NightshadeSeed());

                                }
                                from.AddToBackpack(new Nightshade());
                            }
                        }
                    }
                }     
                else
                {
                    from.SendMessage("You feel you would need a tool to harvest this plant.");
                }                
            }
            else
            {
                from.SendMessage("You are not close enough to harvest this plant.");
            }           
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
            writer.Write((int)m_Harvests);
            writer.Write((DateTime)m_LastHarvested);
            writer.WriteDeltaTime(m_DeathTimer.GetDelay());

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Harvests = reader.ReadInt();
            m_LastHarvested = reader.ReadDateTime();

            DateTime end = reader.ReadDeltaTime();
            m_DeathTimer = new InternalTimer(this, end);
            m_DeathTimer.Start();
        }
    }

    public class NightshadeSeedling : Item
    {
        private InternalTimer m_MaturityTimer;

        [Constructable]
        public NightshadeSeedling()
            : base(0x0DEC)
        {
            Name = "Nightshade Seedling";
            Movable = false;
            Hue = 0x23C;

            var lifespan = Utility.RandomMinMax(360, 480);
            var end = DateTime.Now.AddMinutes(lifespan);
            m_MaturityTimer = new InternalTimer(this, end);
            m_MaturityTimer.Start();
            
        }

        public NightshadeSeedling(Serial serial)
            : base(serial)
        {
        }

        protected class InternalTimer : Timer
        {
            private readonly NightshadeSeedling m_Bush;
            public InternalTimer(NightshadeSeedling bush, DateTime end) : base(end.Subtract(DateTime.Now))
            {
                m_Bush = bush;
                Priority = TimerPriority.FiveSeconds;
            }

            public DateTime GetDelay()
            {
                return this.Next;
            }

            protected override void OnTick()
            {
                if (m_Bush != null && !m_Bush.Deleted)
                {
                    var location = m_Bush.Location;
                    var map = m_Bush.Map;
                    m_Bush.Delete();
                    var matureBush = new NightshadeBush();
                    matureBush.MoveToWorld(location, map);
                }

                Stop();
            }

        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            from.SendMessage("This plant is not mature enough to harvest");
        }
                
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.WriteDeltaTime(m_MaturityTimer.GetDelay());
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            DateTime end = reader.ReadDeltaTime();
            m_MaturityTimer = new InternalTimer(this, end);
            m_MaturityTimer.Start();
        }
    }

    public class NightshadeSeed : Item
    {
        [Constructable]
        public NightshadeSeed()
            : this(1)
        {
        }

        [Constructable]
        public NightshadeSeed(int amount)
            : base(0xDCF)
        {
            this.Name = "Nightshade Seed";
            Stackable = true;
            Weight = .5;
            Hue = 0x23C;
            Movable = true;
            Amount = amount;
        }
        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (from.Mounted)
            {
                from.SendMessage("You cannot plant a seed while mounted.");
                return;
            }

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042010); //You must have the object in your backpack to use it. 
                return;
            }

            var tile = new LandTarget(from.Location, from.Map);

            if (tile.Name == "grass" || tile.Name == "furrows" || tile.Name == "forest" || tile.Name == "jungle")
            {
                var seedling = new NightshadeSeedling();
                from.Freeze(TimeSpan.FromMilliseconds(1500));
                from.PlayAttackAnimation(AttackAnimation.Wrestle);
                from.SendMessage("You plant the seed at your feet.");
                Amount--;
                if (Amount == 0)
                {
                    Delete();
                }

                seedling.MoveToWorld(from.Location, from.Map);
            }
        }
    }
}
