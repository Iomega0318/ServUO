using System;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class UraniumVein : BasePlant
    {
        [Constructable]
        public UraniumVein()
            : this(null)
        {
        }

        [Constructable]
        public UraniumVein(Mobile planter)
            : base(Utility.RandomMinMax(6001, 6012))
        {
            Name = "Uranium Vein";
            Movable = false;
            Hue = 268;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = DateTime.UtcNow.AddSeconds(Utility.RandomMinMax(30, 300));
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Priority = TimerPriority.OneSecond;
            m_DeathTimer.Start();
        }

        public UraniumVein(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!PlantHelper.RangeCheck(this, from))
            {
                from.SendMessage("You are not close enough to mine this.");
                return;
            }

            if (from.Mounted)
            {
                from.SendMessage("You cannot mine this while mounted.");
                return;
            }

            PlantHelper.HarvesterEquippedResult check;
            if (from.FindItemOnLayer(Layer.OneHanded) is UraniumPickaxe t)
            {
                check = new PlantHelper.HarvesterEquippedResult { Result = true, Tool = t };
            }
            else
            {
                check = new PlantHelper.HarvesterEquippedResult { Result = false, Tool = null };
            }

            if (!check.Result)
            {
                from.SendMessage("You feel you would need the proper tool equipped to harvest this.");
                return;
            }
            var tool = check.Tool;

            if (DateTime.Now < m_LastHarvested.AddMilliseconds(1500))
            {
                from.SendLocalizedMessage(500119); // You must wait to perform another action.
                return;
            }

            if (from.Skills[SkillName.Mining].Base < 80.0)
            {
                from.SendMessage("You do not have the skill to mine that.");
                return;
            }

            m_LastHarvested = DateTime.Now;
            Harvests--;
            if (Harvests <= 0)
            {
                Delete();
            }

            tool.UsesRemaining--;
            if (tool.UsesRemaining == 0)
            {
                tool.Delete();
                from.SendMessage("You have broken your uranium pickaxe.");
            }

            from.CheckSkill(SkillName.Mining, 80.0, 160.0);
            from.Freeze(TimeSpan.FromMilliseconds(1500));
            from.PlayAttackAnimation(AttackAnimation.Slash1H);
            Timer.DelayCall(TimeSpan.FromMilliseconds(500), () => from.PlaySound(Utility.RandomMinMax(0x03AA, 0x03AD)));


            //Failure
            if (Utility.RandomMinMax(1, 50) != 1)
            {
                from.SendMessage("You fail to collect the uranium ore.");
                //Critical Fail
                if (.1 > Utility.RandomDouble())
                {
                    from.SendMessage("You hear a disturbing rumble as elementals erupt from the ground.");
                    var tiles = this.GetAllPointsInRange(from.Map, 6);
                    foreach (Point3D tile in tiles)
                    {
                        var lt = new LandTarget(tile, from.Map);
                        if (lt.Flags != TileFlag.Impassable || !lt.IsWater())
                        {
                            if (.10 > Utility.RandomDouble())
                            {
                                var ele = GetRandomElemental();
                                
                                ele.MoveToWorld(lt.Location, this.Map);
                            }
                        }
                    }
                }
            }
            //Success
            else
            {
                from.AddToBackpack(new UraniumOre());
                from.SendMessage("You harvest some uranium ore and put it in your pack");
            }
        }

        private static BaseCreature GetRandomElemental()
        {
            switch (Utility.RandomMinMax(0, 14))
            {
                case 0:
                    return new DullCopperOreElemental();
                case 1:
                    return new ShadowIronOreElemental();
                case 2:
                    return new CopperOreElemental();
                case 3:
                    return new BronzeOreElemental();
                case 4:
                    return new GoldenOreElemental();
                case 5:
                    return new AgapiteOreElemental();
                case 6:
                    return new VeriteOreElemental();
                case 7:
                    return new ValoriteOreElemental();
                case 8:
                    return new BlazeOreElemental();
                case 9:
                    return new IceOreElemental();
                case 10:
                    return new ToxicOreElemental();
                case 11:
                    return new ElectrumOreElemental();
                case 12:
                    return new PlatinumOreElemental();
                default:
                    return new ShameEarthElemental();
            }  
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
