using System;
using Server.Commands;
using Server;
using System.Collections.Generic;
using Server.Items;
using Server.Network;

namespace Bittiez.EggHuntEvent
{
    public class EggHunt
    {
        public static void Initialize()
        {
            CommandSystem.Register("StartEggHunt", AccessLevel.Seer, new CommandEventHandler(StartEggHunt));
        }

        public static void StartEggHunt(CommandEventArgs e)
        {
            Only_One_Egg();
            Item egg = new TheEgg(e.Mobile.Location, e.Mobile.Map);
            World.Broadcast(38, false, "The EggHunt has begun.");

        }

        public static void Only_One_Egg()
        {
            Dictionary<Serial, Item> it = World.Items;

            List<Item> DeleteMe = new List<Item>();

            foreach (Item i in it.Values)
            {
                if ((i is TheEgg || i is TheArrow) && i != null && !i.Deleted)
                {
                    DeleteMe.Add(i);
                }
            }

            foreach (Item ii in DeleteMe)
                ii.Delete();
        }
    }
}

namespace Server.Items
{
    public class TheEgg : Item
    {
        #region Don't edit
        private List<Item> Rewards = new List<Item>();
        #endregion

        public TheEgg(Point3D loc, Map m)
            : base(0x1ECD)
        {
            LootType = LootType.Blessed;
            Movable = false;
            Name = "The EggHunt Egg";
            Hue = 38;

            Rewards.Add(new PowerScroll(Random_Skill(), new Random().Next(95, 121)));
            Rewards.Add(new DeerMask());
            Rewards.Add(new BearMask());
            Rewards.Add(new SmallFishingNetDeed());
            Location = loc;
            Map = m;
            Show_Arrows();
        }

        public SkillName Random_Skill()
        {
            while (true)
            {
                foreach (SkillName s in Enum.GetValues(typeof(SkillName)))
                {
                    if (new Random().Next(10) == 3) return s;
                }
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!Utility.InRange(from.Location, this.Location, 3))
                from.SendMessage(38, "You must be closer to capture the egg!");

            this.Delete();
            from.SendMessage(38, "You pick up the egg, but it crumbles in your hand..");

            Item reward = Rewards[new Random().Next(Rewards.Count)];
            if (reward != null)
                from.AddToBackpack(reward);
            World.Broadcast(38, false, from.Name + " has found the egg!");
        }

        public void Show_Arrows()
        {
            Mobile m;
            Point3D loc;
            foreach (NetState ns in NetState.Instances)
                if (ns.Mobile != null)
                {
                    m = ns.Mobile;
                    if (m.Map == this.Map)
                    {
                        loc = m.Location;
                        loc.Z += 5;
                        new TheArrow(m.GetDirectionTo(this.Location), loc, m.Map);
                        m.SendMessage(38, "The arrow points towards the mystical egg...");
                    }
                }
            Start_Timer(TimeSpan.FromSeconds(20));

        }

        public void Start_Timer(TimeSpan s)
        {
            Server.Timer.DelayCall(s, new Server.TimerCallback(Show_Arrows));
        }

        #region Serialize
        public TheEgg(Serial serial)
            : base(serial)
        {
        }
        public override void Deserialize(GenericReader reader)
        {
            this.Delete();
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        #endregion
    }

    public class TheArrow : Item
    {
        public TheArrow(Direction d, Point3D mtw, Map m)
        {
            LootType = LootType.Blessed;
            Movable = false;
            Name = "arrow";
            int IDD;
            switch (d)
            {
                default:
                case Direction.Up: IDD = 0x206A; break;
                case Direction.North: IDD = 0x206B; break;
                case Direction.Right: IDD = 0x206C; break;
                case Direction.Down: IDD = 0x206E; break;
                case Direction.South: IDD = 0x206F; break;
                case Direction.Left: IDD = 0x2070; break;
                case Direction.West: IDD = 0x2071; break;
                case Direction.East: IDD = 0x206D; break;

            }


            this.ItemID = IDD;
            this.MoveToWorld(mtw, m);
            Start_Timer(TimeSpan.FromSeconds(10));
        }

        public void Start_Timer(TimeSpan s)
        {
            Server.Timer.DelayCall(s, new Server.TimerCallback(Timer_Callback));
        }


        public void Timer_Callback()
        {
            this.Delete();
        }


        #region Serialize
        public TheArrow(Serial serial)
            : base(serial)
        {
        }
        public override void Deserialize(GenericReader reader)
        {
            this.Delete();
        }
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }
        #endregion
    }
}
