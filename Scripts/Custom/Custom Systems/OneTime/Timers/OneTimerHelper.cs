using System;

namespace Server.OneTime.Timers
{
	public static class OneTimerHelper
	{
		public static bool IsPaused { get; set; } = false;

		public static void Initialize()
		{
			EventSink.BeforeWorldSave += PauseOneTime;
			EventSink.AfterWorldSave += ResumeOneTime;
		}

		private static void PauseOneTime(BeforeWorldSaveEventArgs e)
		{
			IsPaused = true;

			OneTimeStart.SendConsoleMsg("GD13 OneTime : System => ><PAUSED><", ConsoleColor.Red);
		}

		private static void ResumeOneTime(AfterWorldSaveEventArgs e)
		{
			IsPaused = false;

			OneTimeStart.SendConsoleMsg("GD13 OneTime : System => Resuming...", ConsoleColor.DarkYellow);
		}

		//Timer Testing Code
		public static int CountMilli { get; set; } = 0;
		public static int CountSec { get; set; } = 0;
		public static int CountMin { get; set; } = 0;

		public static void OneTimeSync()
		{
			if (CountMilli > 0)
			{
				if (CountMilli / CountMin > 4500)
					OneTimeStart.SendConsoleMsg($"GD13 OneTime : Running [GOOD] => [S{CountSec/ CountMin}:M{CountMilli / CountMin} | S60:M6000 max] / Minute", ConsoleColor.DarkCyan);
				else if (CountMilli / CountMin > 3000)
					OneTimeStart.SendConsoleMsg($"GD13 OneTime : Running [AVERAGE] => [S{CountSec / CountMin}:M{CountMilli / CountMin} | S60:M6000 max] / Minute", ConsoleColor.DarkYellow);
				else
					OneTimeStart.SendConsoleMsg($"GD13 OneTime : Running [POOR] => [S{CountSec / CountMin}:M{CountMilli / CountMin} | S60:M6000 max] / Minute", ConsoleColor.DarkRed);
			}

			CountMilli = 0;

			CountSec = 0;

			CountMin = 0;
		}
	}
}
