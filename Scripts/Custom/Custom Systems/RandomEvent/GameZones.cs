using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.RandomEvent
{
    public static class GameZones
    {
        public static Point3D KickTo = new Point3D(1602, 1591, 20);

        public static List<string> Zones = new List<string> { "Deceit", "Despise", "Destard", "Hythloth", "Shame", "Wrong" };

        public static void CheckZoneKick(PlayerMobile pm, string zone)
        {
            if (CheckZone(pm, zone))
            {
                pm.MoveToWorld(KickTo, pm.Map);
            }
        }

        public static bool CheckZone(PlayerMobile pm, string zone)
        {
            if (pm.Map == GameMain.GameMap)
                return pm.Region.IsPartOf(zone);
            else
                return false;
        }

        public static void UpdateZoneTeleports(string zone, bool IsOn)
        {
            List<Teleporter> teleporters = new List<Teleporter>();

            foreach (Item item in World.Items.Values)
            {
                if (item is Teleporter && item.Map == GameMain.GameMap)
                {
                    teleporters.Add(item as Teleporter);
                }
            }

            if (zone == "Deceit")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(4110, 430, 5) ||
                        teleporter.Location == new Point3D(4111, 430, 5) ||
                        teleporter.Location == new Point3D(4112, 430, 5) ||
                        teleporter.Location == new Point3D(5186, 639, 0) ||
                        teleporter.Location == new Point3D(5187, 639, 0) ||
                        teleporter.Location == new Point3D(5188, 639, 0) ||
                        teleporter.Location == new Point3D(5189, 639, 0) ||
                        teleporter.Location == new Point3D(5218, 761, -28) ||
                        teleporter.Location == new Point3D(5219, 761, -28))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }

            if (zone == "Despise")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(1296, 1280, 0) ||
                        teleporter.Location == new Point3D(1296, 1281, 0) ||
                        teleporter.Location == new Point3D(1296, 1282, 0) ||
                        teleporter.Location == new Point3D(5588, 630, 30) ||
                        teleporter.Location == new Point3D(5588, 631, 30) ||
                        teleporter.Location == new Point3D(5588, 632, 30))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }

            if (zone == "Destard")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(1175, 2635, 0) ||

                        teleporter.Location == new Point3D(5135, 991, 0) ||
                        teleporter.Location == new Point3D(5135, 992, 0) ||
                        teleporter.Location == new Point3D(5135, 993, 0) ||
                        teleporter.Location == new Point3D(5135, 994, 0) ||
                        teleporter.Location == new Point3D(5140, 973, 0) ||
                        teleporter.Location == new Point3D(5145, 973, 0) ||
                        teleporter.Location == new Point3D(1176, 2635, 0) ||
                        teleporter.Location == new Point3D(5242, 1007, 0) ||
                        teleporter.Location == new Point3D(5243, 1007, 0) ||
                        teleporter.Location == new Point3D(5244, 1007, 0))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }

            if (zone == "Hythloth")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(4723, 3813, 0) ||
                        teleporter.Location == new Point3D(4722, 3813, 0) ||
                        teleporter.Location == new Point3D(4721, 3813, 0) ||
                        teleporter.Location == new Point3D(5904, 16, 64) ||
                        teleporter.Location == new Point3D(5905, 16, 64) ||
                        teleporter.Location == new Point3D(5906, 16, 64))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }

            if (zone == "Shame")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(512, 1559, 0) ||
                        teleporter.Location == new Point3D(513, 1559, 0) ||
                        teleporter.Location == new Point3D(514, 1559, 0) ||
                        teleporter.Location == new Point3D(5394, 127, 0) ||
                        teleporter.Location == new Point3D(5395, 127, 0) ||
                        teleporter.Location == new Point3D(5396, 127, 0))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }

            if (zone == "Wrong")
            {
                foreach (Teleporter teleporter in teleporters)
                {
                    if (teleporter.Location == new Point3D(2041, 215, 14) ||
                        teleporter.Location == new Point3D(2042, 215, 14) ||
                        teleporter.Location == new Point3D(2043, 215, 14) ||
                        teleporter.Location == new Point3D(5824, 631, 5) ||
                        teleporter.Location == new Point3D(5825, 631, 5))
                    {
                        teleporter.Active = IsOn;
                    }
                }
            }
        }

        public static Point3D SetTeamSpawnPoints(string zone, out Point3D OtherTeam)
        {
            bool SwitchSides = Utility.RandomBool();
            int RandomSpawn = Utility.RandomMinMax(1, 3);

            if (zone == "Deceit")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5187, 631, 0);
                            return new Point3D(5219, 734, -20);
                        case 2:
                            OtherTeam = new Point3D(5167, 571, 0);
                            return new Point3D(5151, 743, 0);
                        case 3:
                            OtherTeam = new Point3D(5146, 618, -50);
                            return new Point3D(5185, 728, 0);
                        default:
                            OtherTeam = new Point3D(5187, 631, 0);
                            return new Point3D(5219, 734, -20);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5219, 734, -20);
                            return new Point3D(5187, 631, 0);
                        case 2:
                            OtherTeam = new Point3D(5151, 743, 0);
                            return new Point3D(5167, 571, 0);
                        case 3:
                            OtherTeam = new Point3D(5185, 728, 0);
                            return new Point3D(5146, 618, -50);
                        default:
                            OtherTeam = new Point3D(5219, 734, -20);
                            return new Point3D(5187, 631, 0);
                    }
                }
            }

            else if (zone == "Despise")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5418, 570, 60);
                            return new Point3D(5607, 791, 60);
                        case 2:
                            OtherTeam = new Point3D(5388, 523, 65);
                            return new Point3D(5435, 803, 60);
                        case 3:
                            OtherTeam = new Point3D(5424, 571, 65);
                            return new Point3D(5509, 939, 20);
                        default:
                            OtherTeam = new Point3D(5418, 570, 60);
                            return new Point3D(5607, 791, 60);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5607, 791, 60);
                            return new Point3D(5418, 570, 60);
                        case 2:
                            OtherTeam = new Point3D(5435, 803, 60);
                            return new Point3D(5388, 523, 65);
                        case 3:
                            OtherTeam = new Point3D(5509, 939, 20);
                            return new Point3D(5424, 571, 65);
                        default:
                            OtherTeam = new Point3D(5607, 791, 60);
                            return new Point3D(5418, 570, 60);
                    }
                }
            }

            else if (zone == "Destard")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5360, 945, 0);
                            return new Point3D(5179, 1011, 0);
                        case 2:
                            OtherTeam = new Point3D(5244, 1003, 0);
                            return new Point3D(5324, 783, 0);
                        case 3:
                            OtherTeam = new Point3D(5258, 856, 0);
                            return new Point3D(5204, 917, -40);
                        default:
                            OtherTeam = new Point3D(5360, 945, 0);
                            return new Point3D(5179, 1011, 0);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5179, 1011, 0);
                            return new Point3D(5360, 945, 0);
                        case 2:
                            OtherTeam = new Point3D(5324, 783, 0);
                            return new Point3D(5244, 1003, 0);
                        case 3:
                            OtherTeam = new Point3D(5204, 917, -40);
                            return new Point3D(5258, 856, 0);
                        default:
                            OtherTeam = new Point3D(5179, 1011, 0);
                            return new Point3D(5360, 945, 0);
                    }
                }
            }

            else if (zone == "Hythloth")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5907, 25, 44);
                            return new Point3D(6103, 35, 27);
                        case 2:
                            OtherTeam = new Point3D(5989, 67, 22);
                            return new Point3D(6114, 226, 23);
                        case 3:
                            OtherTeam = new Point3D(5942, 103, 22);
                            return new Point3D(6046, 223, 44);
                        default:
                            OtherTeam = new Point3D(5907, 25, 44);
                            return new Point3D(6103, 35, 27);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(6103, 35, 27);
                            return new Point3D(5907, 25, 44);
                        case 2:
                            OtherTeam = new Point3D(6114, 226, 23);
                            return new Point3D(5989, 67, 22);
                        case 3:
                            OtherTeam = new Point3D(6046, 223, 44);
                            return new Point3D(5942, 103, 22);
                        default:
                            OtherTeam = new Point3D(6103, 35, 27);
                            return new Point3D(5907, 25, 44);
                    }
                }
            }

            else if (zone == "Shame")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5395, 125, 0);
                            return new Point3D(5650, 103, 10);
                        case 2:
                            OtherTeam = new Point3D(5387, 11, 30);
                            return new Point3D(5698, 20, 10);
                        case 3:
                            OtherTeam = new Point3D(5523, 51, 0);
                            return new Point3D(5674, 12, -10);
                        default:
                            OtherTeam = new Point3D(5395, 125, 0);
                            return new Point3D(5650, 103, 10);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5650, 103, 10);
                            return new Point3D(5395, 125, 0);
                        case 2:
                            OtherTeam = new Point3D(5698, 20, 10);
                            return new Point3D(5387, 11, 30);
                        case 3:
                            OtherTeam = new Point3D(5674, 12, -10);
                            return new Point3D(5523, 51, 0);
                        default:
                            OtherTeam = new Point3D(5650, 103, 10);
                            return new Point3D(5395, 125, 0);
                    }
                }
            }

            else if (zone == "Wrong")
            {
                if (SwitchSides)
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5824, 626, 0);
                            return new Point3D(5703, 639, 0);
                        case 2:
                            OtherTeam = new Point3D(5795, 534, 10);
                            return new Point3D(5865, 594, 15);
                        case 3:
                            OtherTeam = new Point3D(5866, 532, 15);
                            return new Point3D(5789, 594, 10);
                        default:
                            OtherTeam = new Point3D(5824, 626, 0);
                            return new Point3D(5703, 639, 0);
                    }
                }
                else
                {
                    switch (RandomSpawn)
                    {
                        case 1:
                            OtherTeam = new Point3D(5703, 639, 0);
                            return new Point3D(5824, 626, 0);
                        case 2:
                            OtherTeam = new Point3D(5865, 594, 15);
                            return new Point3D(5795, 534, 10);
                        case 3:
                            OtherTeam = new Point3D(5789, 594, 10);
                            return new Point3D(5866, 532, 15);
                        default:
                            OtherTeam = new Point3D(5703, 639, 0);
                            return new Point3D(5824, 626, 0);
                    }
                }
            }

            else
            {
                OtherTeam = new Point3D(0,0,0);
                return new Point3D(0, 0, 0);
            }
        }

        public static Point3D GetItemSpawnPoint(string zone)
        {
            int RandomSpawn = Utility.RandomMinMax(1, 3);

            if (zone == "Deceit")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(5295, 623, -5);
                    case 2: return new Point3D(5328, 545, 6);
                    case 3: return new Point3D(5319, 581, 0);
                    default: return new Point3D(5295, 623, -5);
                }
            }
            else if (zone == "Despise")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(5473, 754, 10);
                    case 2: return new Point3D(5507, 651, 20);
                    case 3: return new Point3D(5385, 681, 20);
                    default: return new Point3D(5473, 754, 10);
                }
            }
            else if (zone == "Destard")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(5165, 839, 0);
                    case 2: return new Point3D(5204, 776, 0);
                    case 3: return new Point3D(5239, 918, -42);
                    default: return new Point3D(5165, 839, 0);
                }
            }
            else if (zone == "Hythloth")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(6085, 178, 0);
                    case 2: return new Point3D(5988, 184, 44);
                    case 3: return new Point3D(5917, 233, 44);
                    default: return new Point3D(6085, 178, 0);
                }
            }
            else if (zone == "Shame")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(5583, 187, 0);
                    case 2: return new Point3D(5448, 179, 0);
                    case 3: return new Point3D(5500, 221, 0);
                    default: return new Point3D(5583, 187, 0);
                }
            }
            else if (zone == "Wrong")
            {
                switch (RandomSpawn)
                {
                    case 1: return new Point3D(5691, 522, 0);
                    case 2: return new Point3D(5732, 559, 20);
                    case 3: return new Point3D(5658, 554, 20);
                    default: return new Point3D(5691, 522, 0);
                }
            }
            else
                return new Point3D(0, 0, 0);
        }
    }
}
