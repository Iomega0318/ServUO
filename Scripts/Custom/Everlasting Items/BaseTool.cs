using Server.Engines.Craft;
using Server.Network;
using System;

namespace Server.Items
{
    public abstract class BaseEverlastingTool : BaseTool
    {
        public bool ShowUsesRemaining
        {
            get { return false; }
            set { }
        }

        public virtual bool BreakOnDepletion => false;

        public override abstract CraftSystem CraftSystem { get; }

        public BaseEverlastingTool(int uses, int itemID) : base(uses, itemID)
        {
        }

        public BaseEverlastingTool(Serial serial)
            : base(serial)
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
