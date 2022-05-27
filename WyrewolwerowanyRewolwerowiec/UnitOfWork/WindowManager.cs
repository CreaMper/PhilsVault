using System;
using System.Runtime.Versioning;
using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;

namespace WyrewolwerowanyRewolwerowiec.UnitOfWork
{
    [SupportedOSPlatform("windows")]
    public class WindowManager
    {
        private ProgressDto _progress;

        public WindowManager(ProgressDto progress)
        {
            _progress = progress;
        }

        public void Initialise()
        {
            //you can add some conditions here
            FirstLaunch();
        }

        public void FirstLaunch()
        {
            Console.Title = "          more          more          more          more          more          more";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorSize = 1;
            Console.Clear();
        }
    }
}
