using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class GarlicPlant : BasePlant
    {
        [Constructable]
        public GarlicPlant()
            : this(null)
        {
        }

        [Constructable]
        public GarlicPlant(Mobile planter)
            : base(Utility.RandomList<int>(new int[] { 0x0C8B, 0x0C8C }))
        {
            Name = "Garlic Plant";
            Movable = false;
            Hue = 1072;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public GarlicPlant(Serial serial)
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
    public class GarlicSeedling : BaseSeedling
    {
        [Constructable]
        public GarlicSeedling() : this(null)
        {
        }

        [Constructable]
        public GarlicSeedling(Mobile planter)
            : base(0x0D32)
        {
            Name = "Garlic Seedling";
            Movable = false;
            Hue = 1072;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public GarlicSeedling(Serial serial)
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
    public class GarlicSeed : BaseSeed
    {
        [Constructable]
        public GarlicSeed()
            : this(1)
        {
        }

        [Constructable]
        public GarlicSeed(int amount)
            : base(0x0C67)
        {
            Name = "Garlic Seed";
            Stackable = true;
            Weight = .5;
            Hue = 1072;
            Movable = true;
            Amount = amount;            
        }

        public GarlicSeed(Serial serial)
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
