using Cryptography;
using PhilsVault.Dto.GameProgress;

namespace PhilsVault.Managers
{
    public class Factory
    {
        public ProgressDto _progress;
        public Encrypt Encrypt = new Encrypt();
        public Decrypt Decrypt = new Decrypt();

        public ProgressManager ProgressManager;
        public WindowManager WindowManager;
        public StageManager StageManager;
        public SoundManager SoundManager;
        public WriteManager WriteManager;
        public AssetManager AssetManager;

        public Factory()
        {
            AssetManager = new AssetManager(Decrypt);
            ProgressManager = new ProgressManager(Encrypt, Decrypt);
            var progress = ProgressManager.Load();
            WindowManager = new WindowManager(progress);
            StageManager = new StageManager(progress, AssetManager, WindowManager);
            SoundManager = new SoundManager(AssetManager);
            WriteManager = new WriteManager();
        }
    }
}
