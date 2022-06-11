using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using System;
using System.Linq;

namespace PhilsLab.Stages
{
    public class StageOne : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;

        public StageOne(ProgressDto progress, string[] args, AssetManager assetManager)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
            _soundManager = new SoundManager(assetManager);
        }

        public void Start()
        {
            if (!_progress.StageOne.LoginPhase)
            {
                Position(5, 150);
                W("Forgot password? Try to start in ");

                CursorChange(ConsoleColor.Yellow, ConsoleColor.Black);
                W("-any-password ");

                CursorChange(ConsoleColor.Green, ConsoleColor.Black);
                W("mode!");
                Position(0, 0);

                Position(43, 5);
                W("LOGIN: ");

                Position(40, 7);
                W("PASSWORD: ");

                Position(51, 5);
                S(2000);

                ConsoleType("phil.forker", 1500, T.W);
                S(400);
                
                if (_args.Contains("recovery") || _args.Contains("-recovery") || _args.Contains("--recovery"))
                {
                    Position(51, 7);
                    ConsoleType("**********", 1500, T.W);

                    AccessGranted();

                    C();

                    Position(0, 0);
                    WL("phil.forker@192.168.25.142# ");

                    S(1500);
                    ConsoleType("con drive 'HALO' -f", 2000, T.W);

                    S(1000);

                    for (int i = 1; i < 5; i++)
                    {
                        WL($"Establishing TLS connection...({i}/4)");
                        S(2200);
                    }

                    WL($"Cannot establish secure connection! Restarting");

                    for (int i = 0; i < 3; i++)
                    {
                        W(".");
                        S(1000);
                    }

                    _progress.StageOne.LoginPhase = true;
                    ProgressManager.Update(_progress);
                    Environment.Exit(0);
                } 
                else
                {
                    Position(51, 7);
                    ConsoleType("**********", 1500, T.W);

                    S(200);

                    ClearPasswordField();
                    AccessDeined();

                    S(1000);
                    ConsoleType("***************", 1500, T.W);

                    S(400);

                    ClearPasswordField();
                    AccessDeined();

                    while (true)
                    {
                        FlushRead();
                        for (int i = 0; i < 10; i++)
                        {
                            Console.ReadKey(true);
                            _factory.SoundManager.PlayType();
                            W("*");
                        }

                        ClearPasswordField();
                        AccessDeined();
                    }
                }
            }
        }

        private void ClearPasswordField()
        {
            Position(51, 7);
            for (int i = 0; i < 120; i++)
                W(" ");
        }

        private void AccessDeined()
        {
            CursorChange(ConsoleColor.Black, ConsoleColor.Red, 51, 3);
            ConsoleType("ACCESS DEINED", 0, T.W);
            Position(51, 7);
            S(3000);

            CursorChange(ConsoleColor.Green, ConsoleColor.Black, 51, 3);
            for (int i = 0; i < 25; i++)
                W(" ");

            ClearPasswordField();

            Position(51, 7);
        }

        private void AccessGranted()
        {
            CursorChange(ConsoleColor.Black, ConsoleColor.Green, 51, 3);
            ConsoleType("ACCESS GRANTED", 0, T.W);
            Position(61, 7);
            S(3000);

            CursorChange(ConsoleColor.Green, ConsoleColor.Black, 51, 3);
        }
    }
}
