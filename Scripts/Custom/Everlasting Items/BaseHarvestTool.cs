using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Engines.Harvest;
using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;

namespace Server.Items
{
    public abstract class BaseEverlastingHarvestTool : BaseHarvestTool
    {
        public bool ShowUsesRemaining
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        public override bool BreakOnDepletion => false;

        public override abstract HarvestSystem HarvestSystem { get; }

        public BaseEverlastingHarvestTool(int itemID) : this(1, itemID)
        {
        }

        public BaseEverlastingHarvestTool(int usesRemaining, int itemID) : base(itemID)
        {

        }

        public override void AddCraftedProperties(ObjectPropertyList list)
        {
        }

        public override void AddUsesRemainingProperties(ObjectPropertyList list)
        {
        }

        public virtual void DisplayDurabilityTo(Mobile m)
        {
        }

        public BaseEverlastingHarvestTool(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }


    }
}
