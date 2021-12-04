using System;
using Server.Targeting;

namespace Server.Items
{
    #region BasePlant
    public abstract class BasePlant : Item
    {
        
        protected int m_Harvests;
        protected DateTime m_LastHarvested;
        protected PlantHelper.DeathTimer m_DeathTimer;
        protected Mobile m_Planter;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Harvests
        {
            get { return m_Harvests; }
            set { m_Harvests = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime Dies
        {
            get { return m_DeathTimer.GetDelay(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Planter
        {
            get { return m_Planter; }
        }

        [Constructable]
        public BasePlant(int itemID) : base(itemID)
        {              
        }

        public BasePlant(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (!PlantHelper.RangeCheck(this, from))
            {
                from.SendMessage("You are not close enough to harvest this plant.");
                return;
            }

            var check = PlantHelper.IsHarvesterEquipped(from);
            if (!check.Result)
            {
                from.SendMessage("You feel you would need a tool to harvest this plant.");
                return;
            }
            var tool = check.Tool;

            if (DateTime.Now < m_LastHarvested.AddMilliseconds(1500))
            {
                from.SendLocalizedMessage(500119); // You must wait to perform another action.
                return;
            }

            if (from.Mounted)
            {
                from.SendMessage("You cannot harvest reagents while mounted.");
                return;
            }

            m_LastHarvested = DateTime.Now;
            Harvests--;
            if (Harvests <= 0)
            {
                Delete();
            }

            PlantHelper.Harvest(this, from, tool);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)4); // version
            writer.Write((int)m_Harvests);
            writer.Write((DateTime)m_LastHarvested);
            writer.Write((Mobile)m_Planter);
            writer.WriteDeltaTime(m_DeathTimer.GetDelay());
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Harvests = reader.ReadInt();
            m_LastHarvested = reader.ReadDateTime();
            m_Planter = reader.ReadMobile();

            DateTime end = reader.ReadDeltaTime();
            m_DeathTimer = new PlantHelper.DeathTimer(this, end);
            m_DeathTimer.Start();
        }
    }
    #endregion

    #region BaseSeedling
    public abstract class BaseSeedling : Item
    {
        protected PlantHelper.MatureTimer m_MaturityTimer;
        protected Mobile m_Planter;        

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime Matures
        {
            get { return m_MaturityTimer.GetDelay().ToLocalTime(); }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Planter
        {
            get { return m_Planter; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TimeSpan MaturesIn
        {
            get { return m_MaturityTimer.GetDelay().Subtract(DateTime.UtcNow); }
        }

        [Constructable]
        public BaseSeedling(int ItemID) : base(ItemID)
        {
        }
        public BaseSeedling(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);
            from.SendMessage("This plant is not mature enough to harvest");
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)4); // version
            writer.Write((Mobile)m_Planter);

            writer.WriteDeltaTime(m_MaturityTimer.GetDelay());
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Planter = reader.ReadMobile();

            DateTime end = reader.ReadDeltaTime();
            m_MaturityTimer = new PlantHelper.MatureTimer(this, end);
            m_MaturityTimer.Start();
        }
    }
    #endregion

    #region BaseSeed
    public abstract class BaseSeed : Item, ICommodity
    {
        [Constructable]
        public BaseSeed(int ItemID) : base(ItemID)
        { 
        }

        public BaseSeed(Serial serial)
            : base(serial)
        {
        }

        TextDefinition ICommodity.Description
        {
            get
            {
                return Name;
            }
        }
        bool ICommodity.IsDeedable
        {
            get
            {
                return true;
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            base.OnDoubleClick(from);

            if (from.Mounted)
            {
                from.SendMessage("You cannot plant a seed while mounted.");
                return;
            }

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042010); //You must have the object in your backpack to use it. 
                return;
            }

            if (!PlantHelper.CanPlantHere(this, from))
            {
                from.SendMessage("You cannot plant here.");
                return;
            }

            PlantHelper.PlantSeed(this, from);
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
