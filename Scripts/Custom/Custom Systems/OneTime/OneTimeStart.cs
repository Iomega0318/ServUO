using System;
using Server.OneTime.Timers;

namespace Server.OneTime
{
    public static class OneTimeStart
    {
        public static Timer TimeMillisecond { get; set; }    
        public static Timer TimeSecond { get; set; }         
        public static Timer TimeMinute { get; set; }
        public static Timer TimeHour { get; set; }
        public static Timer TimeDay { get; set; }

        public static void Initialize()
        {
            EventSink.ServerStarted += OneTimeStarted;
		}

        private static void OneTimeStarted()
		{
			SendConsoleMsg("GD13 OneTime : [Started]", ConsoleColor.DarkCyan);

			if (TimeMillisecond == null)
            {
				TimeMillisecond = new OneMilliTimer
				{
					Priority = TimerPriority.TenMS
				};

				SendConsoleMsg("GD13 OneTime : MilliSecond => Running...", ConsoleColor.Cyan);

			}

            if (TimeSecond == null)
            {
				TimeSecond = new OneSecTimer
				{
					Priority = TimerPriority.OneSecond
				};

				SendConsoleMsg("GD13 OneTime : Second => Running...", ConsoleColor.Cyan);
			}

            if (TimeMinute == null)
            {
				TimeMinute = new OneMinTimer
				{
					Priority = TimerPriority.OneMinute
				};

				SendConsoleMsg("GD13 OneTime : Minute => Running...", ConsoleColor.Cyan);
			}

            if (TimeHour == null)
            {
				TimeHour = new OneHourTimer
				{
					Priority = TimerPriority.OneMinute
				};

				SendConsoleMsg("GD13 OneTime : Hour => Running...", ConsoleColor.Cyan);
			}

            if (TimeDay == null)
            {
				TimeDay = new OneDayTimer
				{
					Priority = TimerPriority.OneMinute
				};

				SendConsoleMsg("GD13 OneTime : Day => Running...", ConsoleColor.Cyan);
			}

            TimeMillisecond.Start();
            TimeSecond.Start();
            TimeMinute.Start();
            TimeHour.Start();
            TimeDay.Start();

			SendConsoleMsg("GD13 OneTime : System => Running...", ConsoleColor.DarkYellow);
		}

		static internal void SendConsoleMsg(string message, ConsoleColor color)
		{
			Console.ForegroundColor = color;

			Console.WriteLine(message);

			Console.ResetColor();
		}
    }
}
