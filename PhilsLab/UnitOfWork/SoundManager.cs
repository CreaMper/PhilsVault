using System.IO;
using System.Media;

namespace PhilsLab.UnitOfWork
{
    public class SoundManager
    {
        private AssetManager _assetManager;
        public SoundManager(AssetManager assetManager)
        {
            _assetManager = assetManager;
        }

        public void Play(string filename)
        {
            var fileByte = _assetManager.GetResource(filename);
            var stream = new MemoryStream(fileByte);

            var player = new SoundPlayer
            {
                Stream = stream
            };

            player.Play();
        }

        public void Stop()
        {
            var player = new SoundPlayer();
            player.Stop();
        }

        public void PlayType()
        {
            var fileByte = _assetManager.GetResource("type.wav");
            var stream = new MemoryStream(fileByte);

            var player = new SoundPlayer
            {
                Stream = stream
            };

            player.Play();
        }
    }
}
