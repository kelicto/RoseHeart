using NAudio.Wave;

namespace KeLi.RoseHeart.App.Utils
{
    public class MusicHelper
    {
        private string _filePath;

        public MusicHelper(string filePath)
        {
            _filePath = filePath;
        }

        public void PlayMusic()
        {
            var waveOutDevice = new WaveOut();
            var audioFileReader = new AudioFileReader(_filePath);

            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }
    }
}