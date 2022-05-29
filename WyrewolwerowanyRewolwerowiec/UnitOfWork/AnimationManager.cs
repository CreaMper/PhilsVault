using System;
using System.Runtime.Versioning;
using WyrewolwerowanyRewolwerowiec.Utils;

namespace WyrewolwerowanyRewolwerowiec.UnitOfWork
{
    [SupportedOSPlatform("windows")]
    public class AnimationManager : WriteManager
    {
        private WindowManager _windowManager;
        private SoundManager _soundManager;

        public AnimationManager(WindowManager windowManager, SoundManager soundManager)
        {
            _windowManager = windowManager;
            _soundManager = soundManager;
        }

        public void Animate(AnimationType type)
        {
            if (type == AnimationType.FirstLaunch)
                FirstLaunch();
            if (type == AnimationType.AlphaJoker)
                AlphaJoker();
        }

        private void FirstLaunch()
        {
            var increment = 0;
            var tittleString = string.Empty;

            for (int i = 0; i < 400; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < increment; k++)
                        W("#");

                    WL("");
                }
                
                double flt = _rand.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                tittleString += Convert.ToChar(shift + 65);

                if (i % 60 == 0)
                    tittleString = string.Empty;

                Console.Title = tittleString;
                increment++;

                B(37 * i, 1);
            }
        }

        private void AlphaJoker()
        {
            Console.SetCursorPosition(10, 20);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            C();

            _soundManager.Play("bigBlack.wav");
            S(400);
            ConsoleType("Riddle me this,", 900, T.W, false);
            S(800);
            ConsoleType(" riddle me that.", 800, T.W, false);
            S(1500);
            ConsoleType(" Who’s afraid ", 500, T.W, false);
            S(100);
            ConsoleType("of the big, black ", 1100, T.W, false);
            S(200);

            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleType("skull?", 500, T.W, false);
            S(2000);

            _windowManager.SetDefault();
        }
    }
}
