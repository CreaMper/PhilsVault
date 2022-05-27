using System;
using System.Runtime.InteropServices;
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

        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        public void LockWindows()
        {
            LockWorkStation();
        }

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr h, string m, string c, int type);
        public int Message(string tittle, string message, int type)
        {
            return MessageBox((IntPtr)0, message, tittle, type);
        }

        public void MessageVoid(string tittle, string message, int type)
        {
            MessageBox((IntPtr)0, message, tittle, type);
        }

        public void SetDefault()
        {
            Console.Title = "Command Prompt";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorSize = 1;
            Console.Clear();
        }

    }
}
