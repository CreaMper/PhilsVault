using Cryptography;
using PhilsVault.Dto.GameProgress;
using PhilsVault.UnitOfWork;

namespace PhilsVault
{
    public class Factory
    {
        public ProgressManager ProgressManager;
        public WindowManager WindowManager;
        public StageManager StageManager;
        public ProgressDto _progress;
        public AnimationManager AnimationManager;
        public SoundManager SoundManager;
        public WriteManager WriteManager;
        public AssetManager AssetManager;
        public Encrypt Encrypt = new Encrypt();
        public Decrypt Decrypt = new Decrypt();

        public Factory()
        {
            AssetManager = new AssetManager(Decrypt);
            ProgressManager = new ProgressManager(Encrypt, Decrypt);
            var progress = ProgressManager.Load();
            WindowManager = new WindowManager(progress);
            StageManager = new StageManager(progress, AssetManager, WindowManager);
            SoundManager = new SoundManager(AssetManager);
            AnimationManager = new AnimationManager(WindowManager, SoundManager);
            WriteManager = new WriteManager();
        }
    }
}
