using System;
using Server.OneTime.Events;

namespace Server.OneTime.Timers
{
    class OneMilliTimer : Timer
    {
		public OneMilliTimer() : base(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(1))
        {
        }

        protected override void OnTick()
		{
			if (!OneTimerHelper.IsPaused)
			{
				OneTimeMilliEvent.SendTick(this, 1);
			}

			OneTimerHelper.CountMilli++;
		}
    }
}
