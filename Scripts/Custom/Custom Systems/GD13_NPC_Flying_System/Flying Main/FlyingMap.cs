using Server.Mobiles;

namespace Server.Flying
{
    public class FlyingMap
    {
        public static int Ceiling { get; set; }
        private static int LeftSide { get; set; }
        private static int RightSide { get; set; }
        private static int TopSide { get; set; }
        private static int BottomSide { get; set; }

        private static bool NullCheck(Mobile m)
        {
            Mobile thisMobile;

            if (m == null)
            {
                return true;
            }
            else
            {
                if (m == m as PlayerMobile)
                {
                    thisMobile = m;

                    if (!thisMobile.Alive)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (m == m as BaseFlying)
                {
                    thisMobile = m;

                    if (!thisMobile.Alive)
                    {
                        return true;
                    }
                    else if (thisMobile.Deleted)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void CheckMap(Mobile m)
        {
            if (NullCheck(m))
                return;

            CheckRegion(m);

            if (m.Map == Map.Felucca)
            {
                LeftSide = 5;
                RightSide = 5100;
                TopSide = 5;
                BottomSide = 4090;
                Ceiling = 90;
            }

            if (m.Map == Map.Trammel)
            {
                LeftSide = 5;
                RightSide = 5100;
                TopSide = 5;
                BottomSide = 4090;
                Ceiling = 90;
            }

            if (m.Map == Map.Ilshenar) //Map blocked, see below in CheckRegion() for more details
            {
                LeftSide = 5;
                RightSide = 2304;
                TopSide = 5;
                BottomSide = 1600;
                Ceiling = 90;
            }

            if (m.Map == Map.Malas)
            {
                LeftSide = 515;
                RightSide = 2555;
                TopSide = 5;
                BottomSide = 2045;
                Ceiling = 90;
            }

            if (m.Map == Map.Tokuno)
            {
                LeftSide = 5;
                RightSide = 1445;
                TopSide = 5;
                BottomSide = 1445;
                Ceiling = 90;
            }

            if (m.Map == Map.TerMur)
            {
                LeftSide = 5;
                RightSide = 1275;
                TopSide = 5;
                BottomSide = 4095;
                Ceiling = 90;
            }
            CheckMapEdge(m);
        }

        private static void CheckMapEdge(Mobile m)
        {
            if (NullCheck(m))
                return;

            if (m.X - 1 <= LeftSide)
            {
                m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
            }
            if (m.X + 1 >= RightSide)
            {
                m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
            }
            if (m.Y - 1 <= TopSide)
            {
                m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
            }
            if (m.Y + 1 >= BottomSide)
            {
                m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
            }
            if (m.Z + 1 >= Ceiling)
            {
                m.Direction = FlyingDirection.ChangeAltitudeDown($"{m.Direction}");
                m.Z--;
            }
        }

        private static void CheckRegion(Mobile m)
        {
            if (NullCheck(m))
                return;

            if (m.Map == Map.Ilshenar)  //If you want to include Ilshenar as a flying map, comment out this method
            {
                m.Flying = false;
            }

            if (m.Map == Map.TerMur)  //If you want to include TerMur as a flying map, comment out this method
            {
                m.Flying = false;
            }

            if (m.Region.IsPartOf<Regions.HouseRegion>())
            {
                if (m.Flying)
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                else
                    m.Flying = false;
            }

            if (m.Region.IsPartOf<Regions.DungeonRegion>())
            {
                if (m.Flying)
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                else
                    m.Flying = false;
            }

            if (m.Region.IsPartOf<Regions.GreenAcres>())
            {
                if (m.Flying)
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                else
                    m.Flying = false;
            }

            if (m.Region.IsPartOf<Regions.Jail>())
            {
                if (m.Flying)
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                else
                    m.Flying = false;
            }
        }
    }
}
