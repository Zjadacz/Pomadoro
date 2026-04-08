using NAudio.Wave;

namespace Pomadoro
{
    internal class AlarmPlayer : IAlarmPlayer
    {
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
