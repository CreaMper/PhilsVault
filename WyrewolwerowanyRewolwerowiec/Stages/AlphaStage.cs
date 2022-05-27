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
        private static Factory _factory;
        
        public AlphaStage(ProgressDto progress)
        {
            _progress = progress;
            _factory = new Factory();
        }

        public void Start()
        {
            if (!_progress.Alpha.AcceptedInvitation) 
            {
/*                S(4000);
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
*/
                _factory.AnimationManager.Animate(AnimationType.FirstLaunch);
                C();
                _factory.WindowManager.Message(@"C:\Windows\security\database\edb.chk", "Thank you, my friend...", 0);

                _progress.Alpha.AcceptedInvitation = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            ConsoleType("Hihihihihihihihih", 1000, T.WL);
        }
    }
}
