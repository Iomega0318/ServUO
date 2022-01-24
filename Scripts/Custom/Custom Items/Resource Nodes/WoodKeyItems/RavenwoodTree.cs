using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class RavenwoodTree : BasePlant
    {
        [Constructable]
        public RavenwoodTree()
            : this(null)
        {
        }

        [Constructable]
        public RavenwoodTree(Mobile planter)
            : base(Utility.RandomList<int>(new int[4] { 0x224A, 0x224B, 0x224C, 0x224D }))
        {
            Name = "Ravenwood Tree";
            Movable = false;
            Hue = 502;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = DateTime.UtcNow.AddSeconds(Utility.RandomMinMax(180, 540));
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Priority = TimerPriority.OneSecond;
            m_DeathTimer.Start();
        }

        public RavenwoodTree(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!PlantHelper.RangeCheck(this, from))
            {
                from.SendMessage("You are not close enough to harvest this.");
                return;
            }

            if (from.Mounted)
            {
                from.SendMessage("You cannot chop this while mounted.");
                return;
            }

            PlantHelper.HarvesterEquippedResult check;            
            if (from.FindItemOnLayer(Layer.OneHanded) is RavenwoodAxe t)
            {
                check = new PlantHelper.HarvesterEquippedResult { Result = true, Tool = t };
            }
            else
            {
                check = new PlantHelper.HarvesterEquippedResult { Result = false, Tool = null };
            }
            
            if (!check.Result)
            {
                from.SendMessage("You feel you would need a proper tool equipped to harvest this.");
                return;
            }
            var tool = check.Tool;

            if (DateTime.Now < m_LastHarvested.AddMilliseconds(1500))
            {
                from.SendLocalizedMessage(500119); // You must wait to perform another action.
                return;
            }            

            if (from.Skills[SkillName.Lumberjacking].Base < 80.0)
            {
                from.SendMessage("You do not have the skill to harvest that.");
                return;
            }

            m_LastHarvested = DateTime.Now;
            Harvests--;
            if (Harvests <= 0)
            {
                Delete();
            }
            //
            tool.UsesRemaining--;
            if (tool.UsesRemaining == 0)
            {
                tool.Delete();
                from.SendMessage("You have broken your ravenwood axe.");                
            }

            from.CheckSkill(SkillName.Lumberjacking, 80.0, 160.0);
            from.Freeze(TimeSpan.FromMilliseconds(1500));
            from.PlayAttackAnimation(AttackAnimation.Slash2H);
            Timer.DelayCall(TimeSpan.FromMilliseconds(500), () => from.PlaySound(Utility.RandomMinMax(0x03AA, 0x03AD)));
            

            //Failure
            if (Utility.RandomMinMax(1, 200) != 1)
            {
                from.SendMessage("You fail to collect the ravenwood.");
                //Critical Fail
                if (.1 > Utility.RandomDouble())
                {
                    from.ApplyPoison(from, Poison.Lethal);
                    from.SendMessage("The toxic sap from the tree splashes and makes contact with your body");
                }
            }
            //Success
            else
            {
                from.AddToBackpack(new RavenwoodLog());
                from.SendMessage("You harvest a ravenwood log and put it in your pack");
            }
            //
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)4); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
    #endregion
}
