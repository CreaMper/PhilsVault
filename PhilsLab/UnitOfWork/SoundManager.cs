using AudioSwitcher.AudioApi.CoreAudio;
using System.IO;
using System.Media;

namespace PhilsVault.UnitOfWork
{
    public class SoundManager
    {
        private int MaxSoundLevel = 3;
        private CoreAudioDevice Device = new CoreAudioController().DefaultPlaybackDevice;
        private AssetManager _assetManager;
        private SoundPlayer soundPlayer;

        public SoundManager(AssetManager assetManager)
        {
            _assetManager = assetManager;
            Device.Volume = MaxSoundLevel;
            soundPlayer = new SoundPlayer();
        }

        public void Play(string filename)
        {
            var fileByte = _assetManager.GetResource(filename);
            var stream = new MemoryStream(fileByte);

            soundPlayer.Stream = stream;

            soundPlayer.Play();
        }

        public void PlayLoop(string filename)
        {
            var fileByte = _assetManager.GetResource(filename);
            var stream = new MemoryStream(fileByte);

            soundPlayer.Stream = stream;

            soundPlayer.PlayLooping();
        }

        public void Stop()
        {
            soundPlayer.Stop();
        }

        public void PlayType()
        {
            var fileByte = _assetManager.GetResource("type01.wav");
            var stream = new MemoryStream(fileByte);

            soundPlayer.Stream = stream;
            soundPlayer.Play();
        }
    }
}
