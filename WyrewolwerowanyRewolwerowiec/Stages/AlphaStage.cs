using System;
using System.Runtime.Versioning;
using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;
using WyrewolwerowanyRewolwerowiec.UnitOfWork;
using WyrewolwerowanyRewolwerowiec.Utils;

namespace WyrewolwerowanyRewolwerowiec.Stages
{
    [SupportedOSPlatform("windows")]
    public class AlphaStage : WriteManager
    {
        private static ProgressDto _progress;
        private static AnimationManager _animationManager;
        private static WindowManager _windowManager;
        
        public AlphaStage(ProgressDto progress)
        {
            _progress = progress;
            _animationManager = new AnimationManager();
            _windowManager = new WindowManager(progress);
        }

        public void Start()
        {
            S(4000);
            ConsoleType("Hi", 1000, T.WL);
            S(2000);
            ConsoleType(", You...", 1000);
            S(1000);
            C();
            ConsoleType("I can't belive that you just started an unknow .exe file with admin privilages...", 2000);
            S(4000);
            C();
            ConsoleType("Are you not affraid that I will make a mess in your system????????!!!!!", 2000);
            S(4000);
            ConsoleType("You should be tho", 1000, T.WL);
            S(2000);
            ConsoleType("You should ", 2000, T.WL);
            ConsoleType("be", 2000);
            S(2000);

            _animationManager.Animate(AnimationType.FirstLaunch);
            C();
            _windowManager.Message(@"C:\Windows\security\database\edb.chk", "Thank you, my friend...", 0);
            Environment.Exit(0);
        }
    }
}
