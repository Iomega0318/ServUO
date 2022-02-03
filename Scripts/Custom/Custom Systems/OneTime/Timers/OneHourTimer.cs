using System;
using Server.OneTime.Events;

namespace Server.OneTime.Timers
{
    class OneHourTimer : Timer
    {
        public OneHourTimer() : base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
        {
        }

        protected override void OnTick()
		{
			if (!OneTimerHelper.IsPaused)
			{
				OneTimeHourEvent.SendTick(this, 1);
			}
		}
    }
}
