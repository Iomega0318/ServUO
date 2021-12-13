using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class BlackPearlPlant : BasePlant
    {                
        [Constructable]
        public BlackPearlPlant()
            : this(null)
        {
        }

        [Constructable]
        public BlackPearlPlant(Mobile planter)
            : base(0x0C63)
        {
            Name = "Black Pearl Plant";
            Movable = false;
            Hue = 342;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public BlackPearlPlant(Serial serial)
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
    public class BlackPearlSeedling : BaseSeedling
    {
        [Constructable]
        public BlackPearlSeedling() : this(null)
        {
        }

        [Constructable]
        public BlackPearlSeedling(Mobile planter)
            : base(0x0C61)
        {
            Name = "Black Pearl Seedling";
            Movable = false;
            Hue = 342;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public BlackPearlSeedling(Serial serial)
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
    public class BlackPearlSeed : BaseSeed
    {
        [Constructable]
        public BlackPearlSeed()
            : this(1)
        {
        }

        [Constructable]
        public BlackPearlSeed(int amount)
            : base(0x0C67)
        {
            Name = "Black Pearl Seed";
            Stackable = true;
            Weight = .5;
            Hue = 342;
            Movable = true;
            Amount = amount;
        }

        public BlackPearlSeed(Serial serial)
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
