namespace Pomadoro
{
    public class PomadoroTimer(
        int workTime, 
        int breakTime, 
        IConsole console, 
        IAlarmPlayer alarmPlayer, 
        IDelayProvider delayProvider)
    {
        public readonly Dictionary<string, int> PhaseCounter = new();

        public async Task Start(bool runOnce = false)
        {
            try
            {
                console.CursorVisible = false;
                do
                {
                    await RunPhase("Work", TimeSpan.FromMinutes(workTime), ConsoleColor.Red);
                    await RunPhase("Break", TimeSpan.FromMinutes(breakTime), ConsoleColor.Green);
                }
                while (!runOnce);
            }
            finally 
            {
                console.CursorVisible = true;
            }
        }

        public async Task RunPhase(string phaseName, TimeSpan duration, ConsoleColor color)
        {
            console.ForegroundColor = color;
            console.WriteLine($"{phaseName} phase starts!");
            console.Title = $"{phaseName} Phase";
            var timeLeft = duration;

            while (timeLeft > TimeSpan.Zero)
            {
                console.Write($"\r{timeLeft:mm\\:ss}");
                console.Title = $"{phaseName} Phase {timeLeft:mm\\:ss}";
                await delayProvider.Delay(TimeSpan.FromSeconds(1));
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
            }

            console.Title = $"{phaseName} Phase finished!";
            console.WriteLine("\r00:00");

            PhaseCounter[phaseName] = PhaseCounter.GetValueOrDefault(phaseName) + 1;
            alarmPlayer.PlaySound();
        }
    }
}
