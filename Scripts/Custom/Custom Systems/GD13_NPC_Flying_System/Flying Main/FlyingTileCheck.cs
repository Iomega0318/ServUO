using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Flying
{
    public class FlyingTileCheck
    {
        private static readonly int[] LavaTiles = new int[]
        {
            0x1F4, 0x1F5,
            0x1F6, 0x1F7,

            4846, 4847, 4848, 4849, 4850,
            4852, 4853, 4854, 4855, 4856,
            4857, 4858, 4859, 4560, 4561,
            4562, 4864, 4865, 4866, 4867,
            4868, 4870, 4871, 4872, 4873,
            4874, 4876, 4877, 4878, 4879,
            4880, 4882, 4883, 4884, 4885,
            4886, 4888, 4889, 4890, 4891,
            4892
        };

        private static readonly int[] WaterTiles = new int[]
        {
            0x00A8, 0x00AB,
            0x0136, 0x0137,
            0x5797, 0x579C,
            0x746E, 0x7485,
            0x7490, 0x74AB,
            0x74B5, 0x75D5
        };

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

        public static bool CheckAbove(Mobile m)
        {
            if (NullCheck(m))
                return true;

            //Check Land Tiles
            LandTile landTile = m.Map.Tiles.GetLandTile(m.X, m.Y);

            if (landTile.Equals(null))
                return false;

            if (landTile.Z > (m.Z + 20))
                return true;

            //Check Static Tiles
            StaticTile[] tiles = m.Map.Tiles.GetStaticTiles((m.X), (m.Y), true);

            if (tiles == null)
                return false;

            bool BadTile = false;

            foreach (StaticTile tile in tiles)
            {
                if (tile.Z > (m.Z + 20))
                    BadTile = true;
            }
            return BadTile;
        }

        public static int CheckLandTile(Mobile m, int Ground)
        {
            if (NullCheck(m))
                return Ground;

            int getX = FlyingDirection.GetDirection($"{m.Direction}", out int getY);

            LandTile landTile = m.Map.Tiles.GetLandTile((m.X + getX), (m.Y + getY));

            LandData lD = TileData.LandTable[landTile.ID & 0x3FFF];

            if (m == m as PlayerMobile || m == m as BaseFlying) 
            {
                if (lD.Name == "rock")
                {
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                }

                if (lD.Name == "water")
                {
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                }

                if (lD.Name == "lava")
                {
                    m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
                }
            }
            return landTile.Z;
        }

        public static int CheckStaticLandTile(Mobile m, int Ground)
        {
            if (NullCheck(m))
                return Ground;

            StaticTile[] tiles = m.Map.Tiles.GetStaticTiles(m.X, m.Y, true);

            if (tiles == null)
                return Ground;

            foreach (StaticTile tile in tiles)
            {
                if (tile.Z > Ground)
                {
                    Ground = (tile.Z + 1);
                }
            }
            return Ground;
        }

        public static bool CheckAheadStaticTile(Mobile m)
        {
            if (NullCheck(m))
                return false;

            int getX = FlyingDirection.GetDirection($"{m.Direction}", out int getY);

            StaticTile[] tiles = m.Map.Tiles.GetStaticTiles((m.X + getX), (m.Y + getY), true);

            if (tiles == null)
                return false;

            bool goodtile = true;
            
            foreach (StaticTile tile in tiles)
            {
                //[NOTE]For now we'll just check for height of the wall etc etc, if you want to restrict tiles, uncomment the code below!

                //bool isWater = (tile.ID >= 0x1796 && tile.ID <= 0x17B2); //not sure if mobs should be restricted over static tiles, like streams, moats, shallow water?

                //if (m == m as BaseFlying) // || m == m as PlayerMobile) *Only restrict Creatures, let player fly over static water & Lava?
                //{
                //    if (isWater)
                //    {
                //        goodtile = false;
                //    }

                //    foreach (int id in WaterTiles)
                //    {
                //        if (id == tile.ID)
                //            goodtile = false;
                //    }

                //    foreach (int id in LavaTiles)
                //    {
                //        if (id == tile.ID)
                //            goodtile = false;
                //    }
                //}

                if ((tile.Height + tile.Z) >= m.Z)
                { 
                    goodtile = false;
                }
                else if ((tile.Z + 1) == m.Z)
                {
                    goodtile = false;
                }
            }

            if (goodtile)
                goodtile = CheckAheadMultiTile(m);
            if (goodtile)
                goodtile = CheckAheadItemTile(m);
            if (goodtile)
                goodtile = CheckAheadMobileTile(m);

            if (!goodtile)
            {
                m.Direction = FlyingDirection.ChangeDirection($"{m.Direction}");
            }
            return goodtile;
        }

        public static bool CheckAheadMultiTile(Mobile m)
        {
            if (NullCheck(m))
                return true;

            int getX = FlyingDirection.GetDirection($"{m.Direction}", out int getY);

            var items = m.Map.GetMultiTilesAt((m.X + getX), (m.Y + getY));

            if (items == null)
                return true;

            bool goodtile = true;

            foreach (var CheckMulti in items)
            {
                foreach (var item in CheckMulti)
                {
                    if (item.X == (m.X + getX))
                    {
                        if (item.Y == (m.Y + getY))
                        {
                            if ((item.Z + 10) >= m.Z)
                            { 
                                goodtile = false;
                            }
                            else if ((item.Z + 1) == m.Z)
                            {
                                goodtile = false;
                            }
                        }
                    }
                }
            }
            return goodtile;
        }

        public static bool CheckAheadItemTile(Mobile m)
        {
            if (NullCheck(m))
                return true;

            int getX = FlyingDirection.GetDirection($"{m.Direction}", out int getY);
            
            Point3D itemLoc = new Point3D(m.X, m.Y, m.Z);

            var items = m.Map.GetItemsInRange(itemLoc);

            if (items == null)
                return true;

            bool goodtile = true;

            foreach (var CheckItem in items)
            {
                if (CheckItem.X == (m.X + getX))
                {
                    if (CheckItem.Y == (m.Y + getY))
                    {
                        if ((CheckItem.Z + 10) >= m.Z)
                        {
                            goodtile = false;
                        }
                        else if ((CheckItem.Z + 1) == m.Z)
                        {
                            goodtile = false;
                        }
                    }
                }
            }

            return goodtile;
        }

        public static bool CheckAheadMobileTile(Mobile m)
        {
            if (NullCheck(m))
                return true;

            int getX = FlyingDirection.GetDirection($"{m.Direction}", out int getY);

            Point3D mobLoc = new Point3D(m.X, m.Y, m.Z);

            var mobs = m.Map.GetMobilesInRange(mobLoc);

            if (mobs == null)
                return true;

            bool goodtile = true;

            foreach (var CheckMobs in mobs)
            {
                if (CheckMobs.X == (m.X + getX))
                {
                    if (CheckMobs.Y == (m.Y + getY))
                    {
                        if ((CheckMobs.Z + 10) >= m.Z)
                        { 
                            goodtile = false;
                        }
                        else if ((CheckMobs.Z + 1) == m.Z)
                        {
                            goodtile = false;
                        }
                    }
                }
            }
            return goodtile;
        }
    }
}
