using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class BloodmossInfestation : BasePlant
    {                
        [Constructable]
        public BloodmossInfestation()
            : this(null)
        {
        }

        [Constructable]
        public BloodmossInfestation(Mobile planter)
            : base(0x0C63)
        {
            Name = "Bloodmoss Infestation";
            Movable = false;
            Hue = 342;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public BloodmossInfestation(Serial serial)
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
    public class BloodmossClump : BaseSeedling
    {
        [Constructable]
        public BloodmossClump() : this(null)
        {
        }

        [Constructable]
        public BloodmossClump(Mobile planter)
            : base(0x0C61)
        {
            Name = "Bloodmoss Clump";
            Movable = false;
            Hue = 342;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public BloodmossClump(Serial serial)
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
    public class BloodmossSpores : BaseSeed
    {
        [Constructable]
        public BloodmossSpores()
            : this(1)
        {
        }

        [Constructable]
        public BloodmossSpores(int amount)
            : base(0x0C67)
        {
            Name = "Bloodmoss Spores";
            Stackable = true;
            Weight = .5;
            Hue = 342;
            Movable = true;
            Amount = amount;
        }

        public BloodmossSpores(Serial serial)
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
