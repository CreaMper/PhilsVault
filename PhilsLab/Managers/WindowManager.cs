using System;
using System.Runtime.InteropServices;
using PhilsVault.Dto.GameProgress;

namespace PhilsVault.Managers
{
    public class WindowManager
    {
        private readonly ProgressDto _progress;

        public WindowManager(ProgressDto progress)
        {
            _progress = progress;
            ConsoleInitialise();
        }

        public void Introduction()
        {
            Console.Title = "Phill's Vault by CDSGames";
            Console.CursorSize = 1;
            Console.Clear();
        }

        public void StageOne(ProgressDto progress)
        {
            if (!_progress.StageOne.LoginPhase || !_progress.StageOne.PhoenixFile)
            {
                Console.Title = "CERN Intranet @ 192.168.25.142";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorSize = 1;
                Console.Clear();
            }

        }

        [DllImport("user32.dll")]
        private static extern bool LockWorkStation();
        public static void LockWindows()
        {
            LockWorkStation();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void ConsoleInitialise()
        {
            const uint ENABLE_QUICK_EDIT = 0x0040;
            const int STD_INPUT_HANDLE = -10;
            const int MF_BYCOMMAND = 0x00000000;
            const int SC_MINIMIZE = 0xF020;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_SIZE = 0xF000;

            Console.WindowHeight = 30;
            Console.WindowWidth = 120;

            IntPtr consoleHandle = GetStdHandle(STD_INPUT_HANDLE);
            uint consoleMode;
            GetConsoleMode(consoleHandle, out consoleMode);

            consoleMode &= ~ENABLE_QUICK_EDIT;
            SetConsoleMode(consoleHandle, consoleMode);

            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
        }
    }
}
