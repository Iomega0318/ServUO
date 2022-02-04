using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Mobiles;

namespace Server.Items
{
    public static class NIWHunger
    {        
        public static void ApplyStarvation(PlayerMobile from)
        {
            from.AddStatMod(new StatMod(StatType.All, "food", -5, TimeSpan.Zero));
            from.SendMessage("You are starving!");            
        }

        public static void ApplyFoodBuff(PlayerMobile from, StatType stat, int intensity)
        {
            from.AddStatMod(new StatMod(stat, "food", intensity, TimeSpan.Zero));
        }

        public static int CalculateHunger(PlayerMobile from)
        {
            var h = 0;
            foreach (var e in from.StomachContents)
            {
                h += e.FillFactor;
            }
            return h;
        }
    }
    public class StomachContentsEntry
    {
        public string Name;
        public int FillFactor;
        public StatType Stat;
        public int Intensity;

        public StomachContentsEntry() { }
        
        public StomachContentsEntry(string name, int fillFactor, StatType stat, int intensity)
        {
            Name = name;
            FillFactor = fillFactor;
            Stat = stat;
            Intensity = intensity;
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(Name);
            writer.Write(FillFactor);
            writer.Write((int)Stat);
            writer.Write(Intensity);
        }
        public static StomachContentsEntry Deserialize(GenericReader reader)
        {
            var e = new StomachContentsEntry
            {
                Name = reader.ReadString(),
                FillFactor = reader.ReadInt(),
                Stat = (StatType)reader.ReadInt(),
                Intensity = reader.ReadInt()
            };
            return e;
        }
    }
}
