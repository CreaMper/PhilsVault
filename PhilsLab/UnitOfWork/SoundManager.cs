using System;
using System.Media;

namespace PhilsLab.UnitOfWork
{
    public class SoundManager
    {
        private string _currentDir = Environment.CurrentDirectory + @"\Assets\Sounds\";

        public void Play(string filename)
        {
            var player = new SoundPlayer
            {
                SoundLocation = _currentDir + filename,
            };

            player.Play();
        }
    }
}
