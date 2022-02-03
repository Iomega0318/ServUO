using System;
using System.Collections.Generic;
using System.Linq;
using Server.OneTime.Events;

namespace Server.OneTime
{
    static class GrassHelper
    {
        private static List<NewStickyGrass> GrassList = new List<NewStickyGrass>();

        public static void Initialize()
        {
            OneTimeSecEvent.SecTimerTick += UpdateGrass;
        }

        public static void UpdateGrass(object o, EventArgs e)
		{
			if (GrassList.Count > 0)
				GrassList.Clear();

			var result = from c in World.Items.Values
						 where c is NewStickyGrass
						 select c as NewStickyGrass;

			GrassList.AddRange(result);

			UpdateList();
        }

        public static void UpdateList()
        {
            if (GrassList.Count > 0)
            {
                foreach (NewStickyGrass grass in GrassList)
                {
                    grass.TimerTick();
                }
            }
        }
    }
}
