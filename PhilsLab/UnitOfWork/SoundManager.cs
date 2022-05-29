using System;
using System.IO;
using System.Media;

namespace PhilsLab.UnitOfWork
{
    public class SoundManager
    {
        private readonly string _currentDir = Environment.CurrentDirectory + @"\Assets\Sounds\";

        public void Play(string filename)
        {
            var player = new SoundPlayer
            {
                SoundLocation = _currentDir + filename,
            };

            player.Play();
        }

        private double CalculateDuration(string fileName)
        {
            var allBytes = File.ReadAllBytes(_currentDir + fileName);
            var byterate = BitConverter.ToInt32(new[] { allBytes[28], allBytes[29], allBytes[30], allBytes[31] }, 0);
            var duration = Math.Round((double)(allBytes.Length - 8) / (double)byterate, 2);
            return duration;
        }

        public void StopType()
        {
            var player = new SoundPlayer();
            player.Stop();
        }

        public void PlayType()
        {
            var fileByte = File.ReadAllBytes(_currentDir + "type.wav");
            var stream = new MemoryStream(fileByte);

            var player = new SoundPlayer
            {
                Stream = stream
            };

            player.Play();
        }
    }
}
