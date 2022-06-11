using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using System;

namespace PhilsLab.Stages
{
    public class Introduction : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;
        private static AnimationManager _animationManager;

        public Introduction(ProgressDto progress, string[] args, AssetManager assetManager)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
            _soundManager = new SoundManager(assetManager);
            C();
        }

        public void Start()
        {
            _soundManager.PlayLoop("intro.wav");

            IntroAnimation();

            ConsoleType("You will see this screen only once, so read carefully...", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("This game requires some IT knowledge, use google as much as you can.", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("Do notes for every stage, sometimes you need to use something from few stages back.", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("You can reset your progress by deleting program data from %roaming% and start over.", 500, T.W, false);
            SetNextLineInSquare();
            SetNextLineInSquare();
            ConsoleType("Press a key to continue...", 500, T.W, false);
            FlushRead();
            Console.ReadKey(true);

            ClearAnimationSquare();
            ConsoleType("Your perceptivity, logical thinking, and IT skills will be tested here...", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("Every detail, every file part, and every name can be a clue.", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("Sometimes this program will exit by itself so you will need to re-run it.", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("Sometimes you will encounter strange behavior - it is intended and harmless.", 500, T.W, false);
            SetNextLineInSquare();
            SetNextLineInSquare();
            ConsoleType("Press a key to continue...", 500, T.W, false);
            FlushRead();
            Console.ReadKey(true);

            ClearAnimationSquare();
            ConsoleType("Before we begin...", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("This game is HARD, but do you want me to give you a hint sometimes?", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("If so, game difficulty will be set to NORMAL instead of HARD.", 500, T.W, false);
            SetNextLineInSquare();
            ConsoleType("What is your decision?[Y/N] :", 500, T.W, false);

            FlushRead();
            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    SetNextLineInSquare();
                    SetNextLineInSquare();
                    ConsoleType("The difficulty level will be lowered then...", 500, T.W, false);
                    break;
                } else if (key == ConsoleKey.N)
                {
                    SetNextLineInSquare();
                    SetNextLineInSquare();
                    ConsoleType("We do have a PRO here, don't we? Great!", 500, T.W, false);
                    break;
                }
            }

            SetNextLineInSquare();
            SetNextLineInSquare();
            ConsoleType("Press a key to continue...", 500, T.W, false);
            FlushRead();
            Console.ReadKey(true);

            ClearAnimationSquare();
            ConsoleType("Time to open Phil's Vault!", 1000, T.W, false);
            S(3000);
            ClearAnimationSquare();

            SetNextLineInSquare();
            Console.SetCursorPosition(20, 20);
            ConsoleType("Be not affraid, ", 2000, T.W, false);
            S(500);
            ConsoleType("stranger...", 2000, T.W, false);
            _soundManager.PlayLoop("error02.wav");
            S(3000);

            _progress.Introduction.Completed = true;
            ProgressManager.Update(_progress);
            Environment.Exit(0);
        }

        private void IntroAnimation()
        {
            WL("    ██████╗ ██╗  ██╗██╗██╗     ███████╗    ██╗   ██╗ █████╗ ██╗   ██╗██╗  ████████╗");
            WL("    ██╔══██╗██║  ██║██║██║     ██╔════╝    ██║   ██║██╔══██╗██║   ██║██║  ╚══██╔══╝");
            WL("    ██████╔╝███████║██║██║     ███████╗    ██║   ██║███████║██║   ██║██║     ██║   ");
            WL("    ██╔═══╝ ██╔══██║██║██║     ╚════██║    ╚██╗ ██╔╝██╔══██║██║   ██║██║     ██║   ");
            WL("    ██║     ██║  ██║██║███████╗███████║     ╚████╔╝ ██║  ██║╚██████╔╝███████╗██║   ");
            WL("    ╚═╝     ╚═╝  ╚═╝╚═╝╚══════╝╚══════╝      ╚═══╝  ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝   ");
            WL("");
            WL("");
            ConsoleType("*******************************************************************************************", 500, T.W, false);

            for (int i = 0; i < 13; i++)
            {
                Console.SetCursorPosition(0, 9 + i);
                ConsoleType("*", 75, T.W, false);

                Console.SetCursorPosition(91, 9 + i);
                ConsoleType("*", 75, T.W, false);
            }
            WL();
            ConsoleType("*******************************************************************************************", 500, T.W, false);
            Console.SetCursorPosition(3, 10);
        }

        private void SetNextLineInSquare()
        {
            Console.CursorTop += 1;
            Console.CursorLeft = 3;
        }

        private void ClearAnimationSquare()
        {
            Console.SetCursorPosition(3, 10);

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 88; j++)
                {
                    W(" ");
                }
                Console.CursorTop += 1;
                Console.CursorLeft = 3;
            }

            Console.SetCursorPosition(3, 10);
        }
    }
}
