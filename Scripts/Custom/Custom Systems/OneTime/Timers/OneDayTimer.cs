using System;
using Server.OneTime.Events;

namespace Server.OneTime.Timers
{
    class OneDayTimer : Timer
    {
        public OneDayTimer() : base(TimeSpan.FromDays(1), TimeSpan.FromDays(1))
        {
        }

        protected override void OnTick()
		{
			if (!OneTimerHelper.IsPaused)
			{
				OneTimeDayEvent.SendTick(this, 1);
			}
		}
    }
}
