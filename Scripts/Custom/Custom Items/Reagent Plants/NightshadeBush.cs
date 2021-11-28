using System;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Engines.Craft;

using CustomsFramework;

namespace Server.Items
{
    public class NightshadeBush : Item
    {
        private int m_Harvests;
        private DateTime m_LastHarvested;

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
            m_Harvests = Utility.Random(8, 4);
            m_LastHarvested = DateTime.Now;
            DefaultDecayTime = TimeSpan.FromHours(48);
            Movable = false;
        }

        public NightshadeBush(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (from.InRange(Location, 1))
            {
                if(from.FindItemOnLayer(Layer.OneHanded) is ReagentHarvester t )
                {
                    if(DateTime.Now > m_LastHarvested.AddMilliseconds(1500))
                    {
                        t.UsesRemaining--;
                        if (t.UsesRemaining == 0)
                        {
                            t.Delete();
                            from.SendMessage("You have broken your reagent harvester.");
                        }
                        from.PlayAttackAnimation(AttackAnimation.Wrestle);
                        m_LastHarvested = DateTime.Now;
                        Harvests--;
                        if(Harvests <= 0)
                        {
                            Delete();
                        }

                        from.CheckSkill(SkillName.Alchemy, 0.0, 80.0);

                        if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 100.0))
                        {
                            from.SendMessage("You fail to collect the reagents and destroyed some in the process.");
                            if(.1 > Utility.RandomDouble())
                            {
                                from.ApplyPoison(from, Poison.Lesser);
                                from.SendMessage("You cut yourself while harvesting.");
                            }
                        }
                        else
                        {
                            from.AddToBackpack(new Nightshade());
                            from.SendMessage("You collect the reagents and put tthem in your pack.");

                            if(from.Skills[SkillName.Alchemy].Value >= 80.0)
                            {
                                if (Utility.RandomDouble() > (from.Skills[SkillName.Alchemy].Value / 100.0))
                                {
                                    from.AddToBackpack(new Nightshade());
                                }
                            }
                        }                        
                    }
                    else
                    {
                        from.SendLocalizedMessage(500119); // You must wait to perform another action.
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

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Harvests = reader.ReadInt();
            m_LastHarvested = reader.ReadDateTime();
        }
    }
}
