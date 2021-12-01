using System;
using Server.Targeting;

namespace Server.Items
{    
    #region Plant
    public class NightshadeBush : BasePlant
    {
        [Constructable]
        public NightshadeBush()
            : this(null)
        {
        }

        [Constructable]
        public NightshadeBush(Mobile planter)
            : base(0x0DEE)
        {
            Name = "Nightshade Bush";
            Movable = false;
            Hue = 0x23C;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public NightshadeBush(Serial serial)
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
    public class NightshadeSeedling : BaseSeedling
    {
        [Constructable]
        public NightshadeSeedling() : this(null)
        {
        }

        [Constructable]
        public NightshadeSeedling(Mobile planter)
            : base(0x0DEC)
        {
            Name = "Nightshade Seedling";
            Movable = false;
            Hue = 0x23C;
            m_Planter = planter;

            var lifespan = Utility.RandomMinMax(360, 480); //360, 480
            var end = DateTime.Now.AddMinutes(lifespan);
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public NightshadeSeedling(Serial serial)
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

    #region Seed
    public class NightshadeSeed : BaseSeed
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
            Name = "Nightshade Seed";
            Stackable = true;
            Weight = .5;
            Hue = 0x23C;
            Movable = true;
            Amount = amount;
        }

        public NightshadeSeed(Serial serial)
            : base(serial)
        {
        }

        //public override void OnDoubleClick(Mobile from)
        //{
        //    base.OnDoubleClick(from);
        //}

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
 
