using System;
using System.Threading;

namespace PhilsVault.Managers
{
    public class WriteManager
    {
        public SoundManager _soundManager;
        public Random _rand = new Random();

        public enum T 
        {
            W,
            WL
        }

        public static void W (string str)
        {
            Console.Write(str);
        }

        public static void WL(string str = null)
        {
            Console.Write($"\n\r{str}");
        }

        public static void S(int time)
        {
            if (time == 0)
                Thread.Sleep(int.MaxValue);

            Thread.Sleep(time);
        }

        public static void CursorChange(ConsoleColor cursor, ConsoleColor background, int xpos = 0, int ypos = 0)
        {
            if (ypos !=0 || xpos != 0)
                Console.SetCursorPosition(xpos, ypos);

            Console.BackgroundColor = background;
            Console.ForegroundColor = cursor;
        }

        public static void Position(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public static void SetDefaultCursor()
        {
            Console.Title = "Command Prompt";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorSize = 1;
            Console.Clear();
        }

        public static void C()
        {
            Console.Clear();
        }

        public void ConsoleType(string str, int speed, T type = T.W, bool enableSound = true)
        {
            var stepTime = Convert.ToInt32(Math.Round((double)speed / (double)str.Length, 0));

            if (type == T.WL)
                W("\n\r");

            foreach (var character in str)
            {
                W(character.ToString());
                if (enableSound)
                    _soundManager.PlayType();
                Thread.Sleep(stepTime);
            }
            if (enableSound)
                _soundManager.Stop();
        }

        public void FlushRead()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
    }
}
