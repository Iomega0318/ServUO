using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class GinsengPlant : BasePlant
    {
        [Constructable]
        public GinsengPlant()
            : this(null)
        {
        }

        [Constructable]
        public GinsengPlant(Mobile planter)
            : base(Utility.RandomList<int>(new int[] { 0x0DC4, 0x0DC5 } ))
        {
            Name = "Ginseng Plant";
            Movable = false;
            Hue = 1072;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public GinsengPlant(Serial serial)
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
    public class GinsengSeedling : BaseSeedling
    {
        [Constructable]
        public GinsengSeedling() : this(null)
        {
        }

        [Constructable]
        public GinsengSeedling(Mobile planter)
            : base(0x0D32)
        {
            Name = "Ginseng Seedling";
            Movable = false;
            Hue = 1072;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public GinsengSeedling(Serial serial)
            : base(serial)
        {
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
    public class GinsengSeed : BaseSeed
    {
        [Constructable]
        public GinsengSeed()
            : this(1)
        {
        }

        [Constructable]
        public GinsengSeed(int amount)
            : base(0x0C67)
        {
            Name = "Garlic Seed";
            Stackable = true;
            Weight = .5;
            Hue = 1072;
            Movable = true;
            Amount = amount;

        }

        public GinsengSeed(Serial serial)
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
