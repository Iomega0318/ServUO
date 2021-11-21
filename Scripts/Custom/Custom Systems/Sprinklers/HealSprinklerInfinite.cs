// 	RunUO 2.0 SVN Version	
using Server;
using System;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Multis;
using Server.Engines.Plants;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;



namespace Server.Items
{

    public class HealSprinklerInfinite : Item, ISecurable
    {
        private SecureLevel m_Level;

        [CommandProperty(AccessLevel.GameMaster)]
        public SecureLevel Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        [Constructable]
        public HealSprinklerInfinite() : base(0x14E7)
        {
            Movable = true;
            Weight = 1.0;
            Name = "a heal sprinkler";
            Hue = 53;
        }

        public HealSprinklerInfinite(Serial serial)
            : base(serial)
        {
        }

        public bool CanBeHealed(PlantItem plant)
        {
            PlantSystem sys = plant.PlantSystem;

            if (plant.PlantStatus >= PlantStatus.DecorativePlant)
                return false;
            else if (sys.Poison == 0)
                return false;

            return true;
        }

        public override void OnDoubleClick(Mobile from)
        {
            BaseHouse house = BaseHouse.FindHouseAt(from);
            if (house == null)
                from.SendLocalizedMessage(1005525);//That is not in your house
            else if (this.Movable)
                from.SendMessage("This must be locked down to use!");
            else
            {
                if (this.IsAccessibleTo(from))
                {
                    Point3D p = new Point3D(this.Location);
                    Map map = this.Map;
                    IPooledEnumerable eable = map.GetItemsInRange(p, 18);
                    bool found = false;


                    foreach (Item item in eable)
                    {
                        if (house.IsInside(item) && item is PlantItem && item.IsLockedDown)
                        {
                            PlantItem plant = (PlantItem)item;
                            if (CanBeHealed(plant))
                            {
                                if (plant.PlantSystem.Poison == 1 && plant.PlantSystem.HealPotion == 0)
                                {
                                    plant.PlantSystem.HealPotion = 1;
                                    found = true;
                                    InvalidateProperties();
                                }
                                if (plant.PlantSystem.Poison == 2 && plant.PlantSystem.HealPotion == 0)
                                {
                                    plant.PlantSystem.HealPotion = 2;
                                    found = true;
                                    InvalidateProperties();
                                }
                                if (plant.PlantSystem.Poison == 2 && plant.PlantSystem.HealPotion == 1)
                                {
                                    plant.PlantSystem.HealPotion = 2;
                                    found = true;
                                    InvalidateProperties();
                                }
                            }
                        }
                    }
                    if (found)
                    {
                        from.SendMessage("The poison on your plants has been treated.");
                        from.PlaySound(0x12);
                    }
                    else
                        from.SendMessage("You have no plants that need healing!");
                }
                else
                    from.SendMessage("You may not access this!");
            }
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            SetSecureLevelEntry.AddTo(from, this, list);
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
            writer.Write((int)m_Level);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Level = (SecureLevel)reader.ReadInt();
        }

    }

}
