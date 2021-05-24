using NAudio.Wave;

namespace KeLi.RoseHeart.App.Utils
{
    public class MusicUtil
    {
        public static void PlayMusic(string filePath)
        {
            var waveOutDevice = new WaveOut();
            var audioFileReader = new AudioFileReader(filePath);

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }
    }
}