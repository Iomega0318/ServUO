using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class SpiderNest : BasePlant
    {                
        [Constructable]
        public SpiderNest()
            : this(null)
        {
        }

        [Constructable]
        public SpiderNest(Mobile planter)
            : base(0x10DA)
        {
            Name = "Spider Nest";
            Movable = false;
            Hue = 0;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public SpiderNest(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
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

    #region Seedling
    public class SmallSpiderNest : BaseSeedling
    {
        [Constructable]
        public SmallSpiderNest() : this(null)
        {
        }

        [Constructable]
        public SmallSpiderNest(Mobile planter)
            : base(0x10D9)
        {
            Name = "Small Spider Nest";
            Movable = false;
            Hue = 0;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public SmallSpiderNest(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendMessage("This nest is not mature enough to harvest");
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

    #region Seed
    public class ClusterOfSpiders : BaseSeed
    {
        [Constructable]
        public ClusterOfSpiders()
            : this(1)
        {
        }

        [Constructable]
        public ClusterOfSpiders(int amount)
            : base(0x1006)
        {
            Name = "Cluster of Spiders";
            Stackable = true;
            Weight = .5;
            Hue = 342;
            Movable = true;
            Amount = amount;
        }

        public ClusterOfSpiders(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version

        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

    }
    #endregion

}
