using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;

namespace PhilsLab
{
    public class Factory
    {
        public ProgressManager ProgressManager;
        public WindowManager WindowManager;
        public StageManager StageManager;
        public ProgressDto _progress;
        public AnimationManager AnimationManager;
        public SoundManager SoundManager;

        public Factory()
        {
            ProgressManager = new ProgressManager();
            var progress = ProgressManager.Load();
            WindowManager = new WindowManager(progress);
            StageManager = new StageManager(progress);
            SoundManager = new SoundManager();
            AnimationManager = new AnimationManager(WindowManager, SoundManager);
        }
    }
}
