using System;
using Server.Targeting;

namespace Server.Items
{
    #region Plant
    public class SulferousAshPile : BasePlant
    {                
        [Constructable]
        public SulferousAshPile()
            : this(null)
        {
        }

        [Constructable]
        public SulferousAshPile(Mobile planter)
            : base(0x0DEA)
        {
            Name = "Pile of Sulferous Ash";
            Movable = false;
            Hue = 1260;

            m_Harvests = PlantHelper.GetHarvests();
            m_LastHarvested = DateTime.Now;
            m_Planter = planter;

            var end = PlantHelper.GetDeathTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }

        public SulferousAshPile(Serial serial)
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
    public class BurningSulfur : BaseSeedling
    {
        [Constructable]
        public BurningSulfur() : this(null)
        {
        }

        [Constructable]
        public BurningSulfur(Mobile planter)
            : base(0xDE3)
        {
            Name = "Burning Sulfur";
            Movable = false;
            Hue = 1266;
            m_Planter = planter;

            var end = PlantHelper.GetMatureTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();

        }

        public BurningSulfur(Serial serial)
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
    public class Sulfur : BaseSeed
    {
        [Constructable]
        public Sulfur()
            : this(1)
        {
        }

        [Constructable]
        public Sulfur(int amount)
            : base(0x0F8F)
        {
            Name = "Sulfur";
            Stackable = true;
            Weight = .5;
            Hue = 1260;
            Movable = true;
            Amount = amount;
        }

        public Sulfur(Serial serial)
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
