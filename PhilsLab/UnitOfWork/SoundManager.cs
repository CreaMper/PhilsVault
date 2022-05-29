using System;
using System.Media;
using System.Runtime.Versioning;

namespace PhilsLab.UnitOfWork
{
    [SupportedOSPlatform("windows")]
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
