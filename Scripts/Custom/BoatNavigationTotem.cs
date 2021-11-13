using Server;
using Server.Commands;
using Server.Gumps;
using Server.Multis;
using Server.Network;

using System;
using System.Text;

namespace Server.Items
{
    public class BoatNavigationTotem : BaseTalisman
    {
        [Constructable]
        public BoatNavigationTotem() : base(0x2F58)
        {
            Name = "Captain's Totem";
            Hue = Utility.RandomBlueHue();

            Attributes.NightSight = 1;

            #region Random Skill Sets And Skill Values

            switch (Utility.Random(2))
            {
                case 1:
                    {
                        // SkillBonuses.SetValues(1, SkillName.Archery, Utility.Random(10, 25));
                        // SkillBonuses.SetValues(2, SkillName.Tactics, Utility.Random(10, 25));
                        // SkillBonuses.SetValues(0, SkillName.Fishing, Utility.Random(10, 25));
                        break;
                    }
                case 0:
                    {
                        // SkillBonuses.SetValues(1, SkillName.Magery, Utility.Random(10, 25));
                        // SkillBonuses.SetValues(2, SkillName.EvalInt, Utility.Random(10, 25));
                        // SkillBonuses.SetValues(0, SkillName.Fishing, Utility.Random(10, 25));
                        break;
                    }
            }

            #endregion
        }

        public override void OnAdded(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                from.SendGump(new BoatControlWheel(from));
            }

            InvalidateProperties();
        }

        public override void OnRemoved(object parent)
        {
            if (parent is Mobile)
            {
                Mobile from = (Mobile)parent;

                from.CloseGump(typeof(BoatControlWheel));
                from.CloseGump(typeof(BoatNavigationControl));
            }

            InvalidateProperties();
        }

        public BoatNavigationTotem(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class BoatControlWheel : Gump
    {
        Mobile caller;

        public static void Initialize()
        {
            CommandSystem.Register("BoatControlWheel", AccessLevel.Administrator, new CommandEventHandler(BoatControlWheel_OnCommand));
        }

        [Usage("BoatControlWheel")]
        [Description("Makes a call to your custom gump.")]
        public static void BoatControlWheel_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(BoatControlWheel)))
                e.Mobile.CloseGump(typeof(BoatControlWheel));
            e.Mobile.SendGump(new BoatControlWheel(e.Mobile));
        }

        public BoatControlWheel(Mobile from) : this()
        {
            caller = from;
        }

        public BoatControlWheel() : base(0, 0)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(299, 175, 204, 235, 3500);
            //AddLabel(321, 191, 90, @"Console Selection");
            AddLabel(324, 192, 90, @" Console Selection"); //new
            AddItem(439, 186, 18174); // Boat Wheel Image
            AddImage(311, 186, 94);
            AddImage(327, 185, 93);


            AddButton(317, 236, 2421, 2422, (int)Buttons.Black, GumpButtonType.Reply, 0);
            AddLabel(359, 260, 595, @"Admiral's Black Label");
            AddButton(317, 289, 2421, 2422, (int)Buttons.White, GumpButtonType.Reply, 0);
            AddLabel(356, 314, 595, @"White Marble Delight");
            AddButton(317, 344, 2421, 2422, (int)Buttons.Transparent, GumpButtonType.Reply, 0);
            AddLabel(358, 369, 595, @"Transparent Dreams");
        }

        public enum Buttons
        {
            Black,
            White,
            Transparent
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case (int)Buttons.Black:
                    {
                        from.SendGump(new BoatNavigationControl(from, BoatNavigationControl.BackgroundType.Black));
                        break;
                    }
                case (int)Buttons.White:
                    {
                        from.SendGump(new BoatNavigationControl(from, BoatNavigationControl.BackgroundType.White));
                        break;
                    }
                case (int)Buttons.Transparent:
                    {
                        from.SendGump(new BoatNavigationControl(from, BoatNavigationControl.BackgroundType.Transparent));
                        break;
                    }
            }
        }
    }

    public class BoatNavigationControl : Gump
    {
        Mobile caller;
        BackgroundType m_BackgroundType;

        public static void Initialize()
        {
            CommandSystem.Register("bcblack", AccessLevel.Administrator, new CommandEventHandler(bcblack_OnCommand));
            CommandSystem.Register("bcwhite", AccessLevel.Administrator, new CommandEventHandler(bcwhite_OnCommand));
            CommandSystem.Register("bctransparent", AccessLevel.Administrator, new CommandEventHandler(bctransparent_OnCommand));
        }

        [Usage("[bcblack")] /// Displays With A Black Background
        [Description("Opens Up A Navigation Console For Players To Use To Control Their Boats")]
        public static void bcblack_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(BoatNavigationControl)))
                e.Mobile.CloseGump(typeof(BoatNavigationControl));
            e.Mobile.SendGump(new BoatNavigationControl(e.Mobile, BackgroundType.Black));
        }

        [Usage("[bcwhite")] /// Displays With A White Background
        [Description("Opens Up A Navigation Console For Players To Use To Control Their Boats")]
        public static void bcwhite_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(BoatNavigationControl)))
                e.Mobile.CloseGump(typeof(BoatNavigationControl));
            e.Mobile.SendGump(new BoatNavigationControl(e.Mobile, BackgroundType.White));
        }

        [Usage("bctransparent")] /// Displays See-Thru Background
        [Description("Makes a call to your custom gump.")]
        public static void bctransparent_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(BoatNavigationControl)))
                e.Mobile.CloseGump(typeof(BoatNavigationControl));
            e.Mobile.SendGump(new BoatNavigationControl(e.Mobile, BackgroundType.Transparent));
        }

        public enum BackgroundType
        {
            Black,
            White,
            Transparent
        }

        public BoatNavigationControl(Mobile from, BackgroundType type) : base(0, 0)
        {
            caller = from;
            m_BackgroundType = type;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);

            #region System Background Colors

            switch (type)
            {
                case BackgroundType.Black:
                    {
                        AddImage(333, 141, 9274);
                        AddImage(343, 152, 9274);

                        break;
                    }
                case BackgroundType.White:
                    {
                        AddBackground(331, 138, 144, 144, 3000);

                        break;
                    }
                case BackgroundType.Transparent:
                    {
                        break; // Transparent
                    }
            }

            #endregion

            AddImage(222, 214, 1417);
            AddImage(504, 214, 1417);
            AddItem(525, 219, 5367);
            AddItem(504, 262, 5368);
            AddItem(242, 221, 16083);
            AddImage(302, 110, 9007);

            AddItem(385, 163, 15946, 795);

            AddBackground(368, 199, 74, 46, 9400); // Black Background
            AddBackground(366, 200, 74, 46, 9450); // White Background
            AddBackground(366, 200, 75, 46, 5120); // Transparent Background

            AddItem(553, 280, 2994);  // Sextant Sign: Gump: 2994

            AddButton(554, 233, 5600, 5604, (int)Buttons.RaiseAnchor, GumpButtonType.Reply, 0);
            AddButton(554, 261, 5606, 5606, (int)Buttons.LowerAnchor, GumpButtonType.Reply, 0);
            AddButton(395, 143, 2117, 11400, (int)Buttons.NorthWest, GumpButtonType.Reply, 0);
            AddButton(396, 263, 2117, 11400, (int)Buttons.SouthEast, GumpButtonType.Reply, 0);
            AddButton(336, 203, 2117, 11400, (int)Buttons.SouthWest, GumpButtonType.Reply, 0);
            AddButton(456, 202, 2117, 11400, (int)Buttons.NorthEast, GumpButtonType.Reply, 0);
            AddButton(436, 162, 2117, 11400, (int)Buttons.North, GumpButtonType.Reply, 0);
            AddButton(355, 244, 2117, 11400, (int)Buttons.South, GumpButtonType.Reply, 0);
            AddButton(353, 163, 2117, 11400, (int)Buttons.West, GumpButtonType.Reply, 0);
            AddButton(438, 244, 2117, 11400, (int)Buttons.East, GumpButtonType.Reply, 0);
            AddButton(239, 229, 5603, 5607, (int)Buttons.PPlankControl, GumpButtonType.Reply, 0);
            AddButton(275, 249, 5601, 5605, (int)Buttons.SPlankControl, GumpButtonType.Reply, 0);

            AddButton(373, 211, 2444, 2443, (int)Buttons.Stop, GumpButtonType.Reply, 0);
            AddLabel(388, 212, 295, @"STOP");

            AddButton(478, 244, 22150, 22151, (int)Buttons.Close, GumpButtonType.Reply, 0);
            AddButton(571, 217, 22404, 22404, (int)Buttons.TurnRight, GumpButtonType.Reply, 0);
            AddButton(476, 198, 9904, 9903, (int)Buttons.NorthEastOne, GumpButtonType.Reply, 0);
            AddButton(309, 199, 9910, 9909, (int)Buttons.SouthWestOne, GumpButtonType.Reply, 0);
            AddButton(392, 116, 9901, 9900, (int)Buttons.NorthWestOne, GumpButtonType.Reply, 0);
            AddButton(393, 284, 9907, 9906, (int)Buttons.SouthEastOne, GumpButtonType.Reply, 0);
            AddButton(217, 217, 22403, 22403, (int)Buttons.TurnLeft, GumpButtonType.Reply, 0);
            AddButton(286, 278, 22400, 22400, (int)Buttons.TurnAround, GumpButtonType.Reply, 0);
            AddButton(435, 215, 9762, 9763, (int)Buttons.ForwardOnCurrentHeading, GumpButtonType.Reply, 0);
            AddButton(358, 215, 9766, 9767, (int)Buttons.BackwardOnCurrentHeading, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            RaiseAnchor,
            LowerAnchor,
            NorthWest,
            SouthEast,
            SouthWest,
            NorthEast,
            North,
            South,
            West,
            East,
            PPlankControl,
            SPlankControl,
            Stop,
            Close,
            TurnRight,
            NorthEastOne,
            SouthWestOne,
            NorthWestOne,
            SouthEastOne,
            TurnLeft,
            TurnAround,
            ForwardOnCurrentHeading,
            BackwardOnCurrentHeading,
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            BaseBoat boat = BaseBoat.FindBoatAt(from, from.Map);

            if (!from.Alive && boat == null)
            {
                return;
            }
            else if (boat == null)
            {
                return;
            }
            else
            {
                switch (info.ButtonID)
                {
                    case (int)Buttons.RaiseAnchor:
                        {
                            from.Say("Raise The Anchor!");
                            //boat.RaiseAnchor(true);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.LowerAnchor:
                        {
                            from.Say("Lower The Anchor!");
                            //boat.LowerAnchor(true);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.NorthWest:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: North Northwest!!");
                                boat.StartMove(Direction.Up, true);
                            }
                            else if (boat.Facing != Direction.North)
                            {
                                if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northwest!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Northwest!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northwest!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Northwest!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northwest!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Northwest!!");
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.SouthEast:
                        {
                            if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: South Southeast!!");
                                boat.StartMove(Direction.Up, true);
                            }
                            else if (boat.Facing != Direction.South)
                            {
                                if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southeast!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Southeast!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.North)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southeast!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Southeast!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southeast!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Southeast!!");
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.SouthWest:
                        {
                            if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: South Southwest!");
                                boat.StartMove(Direction.Right, true);
                            }
                            else if (boat.Facing != Direction.South)
                            {
                                if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southwest!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Southwest!!");
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.North)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southwest!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Southwest!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: South Southwest!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: West Southwest!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.NorthEast:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: North Northeast!");
                                boat.StartMove(Direction.Right, true);
                            }
                            else if (boat.Facing != Direction.North)
                            {
                                if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northeast!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Northeast!!");
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northeast!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Northeast!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(2))
                                    {
                                        case 1:
                                            {
                                                from.Say("Set Heading: North Northeast!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.Right, true);
                                                break;
                                            }
                                        case 0:
                                            {
                                                from.Say("Set Heading: East Northeast!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.Up, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.North:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: Due North!!");
                                boat.StartMove(Direction.North, true);
                            }
                            else if (boat.Facing != Direction.North)
                            {
                                if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due North!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due North!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due North!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.South:
                        {
                            if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: Due South!!");
                                boat.StartMove(Direction.North, true);
                            }
                            else if (boat.Facing != Direction.South)
                            {
                                if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due South!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.North)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due South!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due South!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.West:
                        {
                            if (boat.Facing == Direction.West)
                            {
                                from.Say("Set Heading: Due West!!");
                                boat.StartMove(Direction.North, true);
                            }
                            else if (boat.Facing != Direction.West)
                            {
                                if (boat.Facing == Direction.North)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due West!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.East)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due West!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due West!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.East:
                        {
                            if (boat.Facing == Direction.East)
                            {
                                from.Say("Set Heading: Due East!!");
                                boat.StartMove(Direction.North, true);
                            }
                            else if (boat.Facing != Direction.East)
                            {
                                if (boat.Facing == Direction.South)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due East!!");
                                                boat.Turn(270, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.West)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due East!!");
                                                boat.Turn(180, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                                else if (boat.Facing == Direction.North)
                                {
                                    switch (Utility.Random(1))
                                    {
                                        case 0:
                                            {
                                                from.Say("Set Heading: Due East!!");
                                                boat.Turn(90, true);
                                                boat.StartMove(Direction.North, true);
                                                break;
                                            }
                                    }
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.PPlankControl:
                        {
                            from.Say("Extend The Port Plank!!");
                            boat.PPlank.Open();
                            boat.PPlank.Locked = false;

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.SPlankControl:
                        {
                            from.Say("Extend The Starboard Plank!!");
                            boat.SPlank.Open();
                            boat.SPlank.Locked = false;

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.Stop:
                        {
                            from.Say("Stop The Ship!!");
                            boat.StopMove(true);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.Close:
                        {
                            from.CloseGump(typeof(BoatNavigationControl));
                            break;
                        }
                    case (int)Buttons.TurnRight:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Change Course! New Heading: Due East!");
                                boat.Turn(90, true);
                            }
                            else if (boat.Facing != Direction.North)
                            {
                                if (boat.Facing == Direction.East)
                                {
                                    from.Say("Change Course! New Heading: Due South!");
                                    boat.Turn(90, true);
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    from.Say("Change Course! New Heading: Due West!");
                                    boat.Turn(90, true);
                                }
                                else if (boat.Facing == Direction.West)
                                {
                                    from.Say("Change Course! New Heading Due North!");
                                    boat.Turn(90, true);
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.NorthEastOne:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: One Right!");
                                boat.OneMove(Direction.East);
                            }
                            else if (boat.Facing == Direction.East)
                            {
                                from.Say("Set Heading: One Right!");
                                boat.OneMove(Direction.East);
                            }
                            else if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: One Right!");
                                boat.OneMove(Direction.East);
                            }
                            else if (boat.Facing == Direction.West)
                            {
                                from.Say("Set Heading: One Right!");
                                boat.OneMove(Direction.East);
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.SouthWestOne: // Left One
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: One Left!");
                                boat.OneMove(Direction.West);
                            }
                            else if (boat.Facing == Direction.East)
                            {
                                from.Say("Set Heading: One Left!");
                                boat.OneMove(Direction.West);
                            }
                            else if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: One Left!");
                                boat.OneMove(Direction.West);
                            }
                            else if (boat.Facing == Direction.West)
                            {
                                from.Say("Set Heading: One Left!");
                                boat.OneMove(Direction.West);
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.NorthWestOne: // Forward One
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: One Forward!");
                                boat.OneMove(Direction.North);
                            }
                            else if (boat.Facing == Direction.East)
                            {
                                from.Say("Set Heading: One Forward!");
                                boat.OneMove(Direction.North);
                            }
                            else if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: One Forward!");
                                boat.OneMove(Direction.North);
                            }
                            else if (boat.Facing == Direction.West)
                            {
                                from.Say("Set Heading: One Forward!");
                                boat.OneMove(Direction.North);
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.SouthEastOne:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Set Heading: One Backward!");
                                boat.OneMove(Direction.South);
                            }
                            else if (boat.Facing == Direction.East)
                            {
                                from.Say("Set Heading: One Backward!");
                                boat.OneMove(Direction.South);
                            }
                            else if (boat.Facing == Direction.South)
                            {
                                from.Say("Set Heading: One Backward!");
                                boat.OneMove(Direction.South);
                            }
                            else if (boat.Facing == Direction.West)
                            {
                                from.Say("Set Heading: One Backward!");
                                boat.OneMove(Direction.South);
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.TurnLeft:
                        {
                            if (boat.Facing == Direction.North)
                            {
                                from.Say("Change Course! New Heading: Due West!");
                                boat.Turn(-90, true);
                            }
                            else if (boat.Facing != Direction.North)
                            {
                                if (boat.Facing == Direction.West)
                                {
                                    from.Say("Change Course! New Heading: Due South!");
                                    boat.Turn(-90, true);
                                }
                                else if (boat.Facing == Direction.South)
                                {
                                    from.Say("Change Course! New Heading: Due East!");
                                    boat.Turn(-90, true);
                                }
                                else if (boat.Facing == Direction.East)
                                {
                                    from.Say("Change Course! New Heading: Due North!");
                                    boat.Turn(-90, true);
                                }
                            }

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.TurnAround:
                        {
                            from.Say("Come About!!");
                            boat.Turn(180, true);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.ForwardOnCurrentHeading:
                        {
                            // Code: boat.Speed = 1
                            // Originally Worked But Caused Boats To Beach Themselves On Land

                            boat.StartMove(Direction.North, false);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                    case (int)Buttons.BackwardOnCurrentHeading:
                        {
                            // Code: boat.Speed = -1
                            // Originally Worked But Caused Boats To Beach Themselves On Land

                            boat.StartMove(Direction.South, false);

                            from.SendGump(new BoatNavigationControl(from, m_BackgroundType));
                            break;
                        }
                }
            }
        }
    }
}