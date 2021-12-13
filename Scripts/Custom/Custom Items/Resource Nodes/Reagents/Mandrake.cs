using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class MandrakePlant : BasePlant
    {                
        [Constructable]
        public MandrakePlant()
            : this(null)
        {
        }

        [Constructable]
        public MandrakePlant(Mobile planter)
            : base(0x0C63)
        {
            Name = "Mandrake Plant";
            Movable = false;
            Hue = 342;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public MandrakePlant(Serial serial)
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
    public class MandrakeSeedling : BaseSeedling
    {
        [Constructable]
        public MandrakeSeedling() : this(null)
        {
        }

        [Constructable]
        public MandrakeSeedling(Mobile planter)
            : base(0x0C61)
        {
            Name = "Mandrake Seedling";
            Movable = false;
            Hue = 342;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public MandrakeSeedling(Serial serial)
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
    public class MandrakeSeed : BaseSeed
    {
        [Constructable]
        public MandrakeSeed()
            : this(1)
        {
        }

        [Constructable]
        public MandrakeSeed(int amount)
            : base(0x0C67)
        {
            Name = "Mandrake Seed";
            Stackable = true;
            Weight = .5;
            Hue = 342;
            Movable = true;
            Amount = amount;
        }

        public MandrakeSeed(Serial serial)
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
