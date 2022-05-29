using System;
using PhilsLab.Utils;

namespace PhilsLab.UnitOfWork
{
    public class AnimationManager : WriteManager
    {
        private readonly WindowManager _windowManager;
        private readonly SoundManager _soundManager;

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
            CursorChange(ConsoleColor.Red, ConsoleColor.White, 10, 20);
            C();

            _soundManager.Play("bigBlack.wav");
            S(400);
            ConsoleType("Riddle me this,", 900, T.W);
            S(800);
            ConsoleType(" riddle me that.", 800, T.W);
            S(1500);
            ConsoleType(" Who’s afraid ", 500, T.W);
            S(100);
            ConsoleType("of the big, black ", 1100, T.W);
            S(200);

            Console.BackgroundColor = ConsoleColor.Black;
            ConsoleType("skull?", 500, T.W);
            S(2000);

            SetDefaultCursor();
        }
    }
}
