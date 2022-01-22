using System;
using Server.Engines.Craft;
using Server.ContextMenus;

namespace Server.Items
{
    [Flipable(0x1EB8, 0x1EB9)]
    public class EverlastingTinkerTools : BaseEverlastingTool
    {
        public override CraftSystem CraftSystem => DefTinkering.CraftSystem;

        [Constructable]
        public EverlastingTinkerTools()
            : this(1)
        {
        }

        [Constructable]
        public EverlastingTinkerTools(int uses)
            : base(uses, 0x1EB8)
        {
            Weight = 0.0;
            LootType = LootType.Blessed;
            Name = "Everlasting Tinkers Tools";
            Hue = 1153;
        }

        public EverlastingTinkerTools(Serial serial)
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

        public override void GetContextMenuEntries(Mobile from, System.Collections.Generic.List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (Core.TOL)
                list.Add(new ToggleRepairContextMenuEntry(from, this));
        }

        public class ToggleRepairContextMenuEntry : ContextMenuEntry
        {
            private Mobile _From;
            private BaseTool _Tool;

            public ToggleRepairContextMenuEntry(Mobile from, BaseTool tool)
                : base(1157040) // Toggle Repair Mode
            {
                _From = from;
                _Tool = tool;
            }

            public override void OnClick()
            {
                if (_Tool.RepairMode)
                {
                    _From.SendLocalizedMessage(1157042); // This tool is fully functional. 
                    _Tool.RepairMode = false;
                }
                else
                {
                    _From.SendLocalizedMessage(1157041); // This tool will only repair items in this mode.
                    _Tool.RepairMode = true;
                }
            }
        }
    }
}
