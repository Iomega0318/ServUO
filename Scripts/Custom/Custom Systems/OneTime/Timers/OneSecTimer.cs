using System;
using Server.OneTime.Events;

namespace Server.OneTime.Timers
{
    class OneSecTimer : Timer
    {
        public OneSecTimer() : base(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
        {
        }

        protected override void OnTick()
		{
			if (!OneTimerHelper.IsPaused)
			{
				OneTimeSecEvent.SendTick(this, 1);
			}

			OneTimerHelper.CountSec++;
		}
    }
}
