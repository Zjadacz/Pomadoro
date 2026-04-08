using NAudio.Wave;

namespace Pomadoro
{
    internal class PomadoroTimer
    {
        public int WorkTime { get; }
        public int BreakTime { get; }

        public PomadoroTimer(int workTime, int breakTime)
        {
            WorkTime = workTime;
            BreakTime = breakTime;
        }

        public async Task Start()
        {
            try
            {
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Work phase starts!");
                Console.Title = "Work Phase";

                while (true)
                {
                    // Working
                    var workTimeSpan = TimeSpan.FromMinutes(WorkTime);
                    while (workTimeSpan > TimeSpan.Zero)
                    {
                        Console.Write($"\r{workTimeSpan:mm\\:ss}");
                        await Task.Delay(1000);
                        workTimeSpan = workTimeSpan.Subtract(TimeSpan.FromSeconds(1));
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\rFinished work phase. Break phase starts!");
                    Console.Title = "Break Phase";
                    PlaySound();

                    // Break
                    var breakTimeSpan = TimeSpan.FromMinutes(BreakTime);
                    while (breakTimeSpan > TimeSpan.Zero)
                    {
                        Console.Write($"\r{breakTimeSpan:mm\\:ss}");
                        await Task.Delay(1000);
                        breakTimeSpan = breakTimeSpan.Subtract(TimeSpan.FromSeconds(1));
                    }

                    Console.WriteLine("\rFinished break. Work phase starts!");
                    Console.Title = "Work Phase";
                    PlaySound();
                }
            }
            finally 
            {
                Console.CursorVisible = true;
            }
        }

        public void PlaySound()
        {
            using var audioFile = new AudioFileReader("melody_alarm.wav");
            using var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

            while (outputDevice.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(100);
            }
        }
    }
}
