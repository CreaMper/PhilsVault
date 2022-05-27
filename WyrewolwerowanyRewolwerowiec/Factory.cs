
using System.Runtime.Versioning;
using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;
using WyrewolwerowanyRewolwerowiec.UnitOfWork;

namespace WyrewolwerowanyRewolwerowiec
{
    [SupportedOSPlatform("windows")]
    public class Factory
    {
        public ProgressManager ProgressManager;
        public WindowManager WindowManager;
        public StageManager StageManager;
        public ProgressDto _progress;

        public Factory()
        {
            ProgressManager = new ProgressManager();
            var progress = ProgressManager.Load();
            WindowManager = new WindowManager(progress);
            StageManager = new StageManager(progress);
        }
    }
}
