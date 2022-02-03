using System;
using Server.OneTime.Events;

namespace Server.OneTime.Timers
{
    class OneMinTimer : Timer
    {
        public OneMinTimer() : base(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1))
        {
        }

        protected override void OnTick()
		{
			if (!OneTimerHelper.IsPaused)
			{
				OneTimeMinEvent.SendTick(this, 1);
			}

			if (OneTimerHelper.CountMin > 9)
			{
				OneTimerHelper.OneTimeSync();
			}
			else
			{
				OneTimerHelper.CountMin++;
			}
		}
    }
}
