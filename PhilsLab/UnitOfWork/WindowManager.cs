using System;
using System.Runtime.InteropServices;
using PhilsLab.Dto.GameProgress;

namespace PhilsLab.UnitOfWork
{
    public class WindowManager
    {
        private readonly ProgressDto _progress;

        public WindowManager(ProgressDto progress)
        {
            _progress = progress;
        }

        public void Initialise()
        {
            DisableQuickEdit();
            FirstLaunch();
        }

        public static void FirstLaunch()
        {
            Console.Title = "          mood          mood          mood          mood          mood          mood";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorSize = 1;
            Console.Clear();
        }

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();
        public static void LockWindows()
        {
            LockWorkStation();
        }

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr h, string m, string c, int type);
        public static int Message(string tittle, string message, int type)
        {
            return MessageBox((IntPtr)0, message, tittle, type);
        }

        public static void MessageVoid(string tittle, string message, int type)
        {
            _ = MessageBox((IntPtr)0, message, tittle, type);
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        public static void DisableQuickEdit()
        {
            const uint ENABLE_QUICK_EDIT = 0x0040;
            const int STD_INPUT_HANDLE = -10;

            IntPtr consoleHandle = GetStdHandle(STD_INPUT_HANDLE);
            uint consoleMode;
            GetConsoleMode(consoleHandle, out consoleMode);

            consoleMode &= ~ENABLE_QUICK_EDIT;
            SetConsoleMode(consoleHandle, consoleMode);
        }
    }
}
