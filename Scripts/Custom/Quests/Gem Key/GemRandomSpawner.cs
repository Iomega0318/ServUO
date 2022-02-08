#region References
using System;
using System.Collections.Generic;
using System.IO;

using Server.Engines.Quests;

using VitaNex.Schedules;
#endregion

namespace Server.Engines
{
    public static class GemRandomQuestSpawner
    {
        private static readonly Point3D[] _Points =
        {
            new Point3D(1453, 1687, 0),//Britain
            new Point3D(3508, 2547, 20),//New Haven
            new Point3D(1444, 3980, 0),//Jhelom
            new Point3D(2502, 430, 15),//Minoc
            new Point3D(3774, 1120, 0),//Nujel'm
            new Point3D(5661, 3148, 13),//Papua
            new Point3D(1901, 2806, 20),//Trinsic
            new Point3D(2874, 723, 0),//Vesper
        };

        private static readonly Type[] _Types =
        {
            typeof(GemKeyQuester),
        };

        private static readonly string _Path = Path.Combine(Core.BaseDirectory, "Saves", "Custom", "GemRandomQuestSpawner.bin");

        public static Dictionary<Point3D, Mobile> Spawn { get; private set; }

        public static Schedule Schedule { get; private set; }

        static GemRandomQuestSpawner()
        {
            Spawn = new Dictionary<Point3D, Mobile>();

            Schedule = new Schedule("Gem Random Quest Spawner", true, ScheduleMonths.All, ScheduleDays.All, ScheduleTimes.Noon, s => OnTick())
            {
                IsLocal = true
            };

            Schedule.Register(); // configurable via [Schedules
        }

        public static void Configure()
        {
            EventSink.WorldSave += e =>
            {
                Persistence.Serialize(_Path, writer =>
                {
                    writer.SetVersion(0);

                    writer.WriteDictionary(Spawn, (w, loc, mob) =>
                    {
                        w.Write(loc);
                        w.Write(mob);
                    });

                    Schedule.Serialize(writer);
                });
            };

            EventSink.WorldLoad += () =>
            {
                Persistence.Deserialize(_Path, reader =>
                {
                    reader.GetVersion();

                    reader.ReadDictionary(r =>
                    {
                        var loc = r.ReadPoint3D();
                        var mob = r.ReadMobile();

                        return new KeyValuePair<Point3D, Mobile>(loc, mob);
                    }, Spawn);

                    Schedule.Deserialize(reader);
                });
            };
        }

        // perform an action at the scheduled time
        private static void OnTick()
        {
            var p = _Points.GetRandom();

            foreach (var kv in Spawn)
            {
                if (kv.Key != p && kv.Value != null)
                {
                    kv.Value.Delete();
                }
            }

            Spawn.RemoveValueRange(m => m == null || m.Deleted);

            if (!Spawn.TryGetValue(p, out var mob) || mob == null || mob.Deleted)
            {
                var type = _Types.GetRandom();

                if (type != null)
                {
                    var map = Utility.RandomList(Map.Trammel,Map.Felucca);

                    var loc = p.GetRandomPoint3D(0, 4, map, false, true);

                    if (loc != Point3D.Zero)
                    {
                        mob = type.CreateInstance<Mobile>();

                        if (mob != null)
                        {
                            mob.OnBeforeSpawn(loc, map);
                            mob.MoveToWorld(loc, map);
                            mob.OnAfterSpawn();

                            if (!mob.Deleted)
                            {
                                Spawn[p] = mob;
                            }
                        }
                    }
                }
            }
        }
    }
}
