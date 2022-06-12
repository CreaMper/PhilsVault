using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhilsLab.Stages
{
    public class StageOne : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;
        private static AssetManager _assetManager;

        public StageOne(ProgressDto progress, string[] args, AssetManager assetManager)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
            _soundManager = new SoundManager(assetManager);
            _assetManager = assetManager;
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
                
                if (_args.Contains("-any-password") || _args.Contains("any-password") || _args.Contains("--any-password"))
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

            if (!_progress.StageOne.PhoenixFile)
            {
                Position(0, 0);
                W("phil.forker@192.168.25.142# ");

                S(1500);
                ConsoleType("con drive 'HALO' -f", 2000, T.W);

                S(1000);

                for (int i = 1; i < 3; i++)
                {
                    WL($"Establishing TLS connection...({i}/4)");
                    S(2200);
                }

                WL("Connection successful!");
                S(300);

                WL("Fetching Data...");
                S(500);
                WL("Downloading Data...");
                S(2500);

                WL("");
                WL("Last changed: 29.04.2022");
                S(400);
                WL("Current date: 25.05.2022");
                S(400);

                WL("");
                WL("Found files:");
                WL("2503452 \t log.txt ");
                WL("1743455 \t exp-gci-2548290.corr");
                S(300);
                WL("");
                WL("phil.forker@192.168.25.142# ");

                S(6000);
                ConsoleType(@"xcopy * .\HALO", 2200, T.W);
                S(600);
                WL("Downloading data...");
                S(500);

                //File creation
                if (!Directory.Exists("HALO"))
                    Directory.CreateDirectory("HALO");

                if (!File.Exists(@"HALO\log.txt"))
                {
                    var fileData = _assetManager.GetResource("phoenixFile_log.txt"); //Add log file more info 
                    File.WriteAllBytes(@"HALO\log.txt", fileData);
                }


                if (!File.Exists(@"HALO\exp-gci-2548290.corr"))
                {
                    var fileData = _assetManager.GetResource("phoenixFile_doc.jpg");
                    File.WriteAllBytes(@"HALO\exp-gci-2548290.corr", fileData);
                }
                ///////////////////

                WL("Downloading data...");
                S(500);
                WL("Downloading data...");
                S(500);

                WL(@"Download complete! Saved to .\HALO");
                WL("");
                S(1500);

                WL("phil.forker@192.168.25.142# ");

                S(180000);

                ConsoleType(@"con db 'physic-dep' 110 021", 2800, T.W);
                S(1200);

                WL($"Establishing TLS connection...(1/4)");
                S(2000);

                WL("Connection successful!");
                S(1000);

                WL("Welcome to Physic Department!");
                WL("");
                S(1000);

                WL("phil.forker@192.168.211.21# ");
                S(4000);

                ConsoleType(@"get exp gci 2548290", 2200, T.W);
                S(1000);

                WL("To access to experiment details, please provide experiment date DD-MM-YYYY!");
                S(1200);

                WL("");

                while (true)
                {
                    WL("phil.forker@192.168.211.21# ");
                    W("");

                    FlushRead();
                    var data = new List<string>();
                    for (int i = 0; i < 10; i++)
                    {
                        var key = Console.ReadKey(false);
                        data.Add(key.KeyChar.ToString());
                        _factory.SoundManager.PlayType();
                    }

                    var dataString = string.Empty;

                    foreach (var dataChar in data)
                        dataString += dataChar;

                    if (!dataString.Equals("25-04-2022"))
                    {
                        WL($"Date of '{dataString}' is not correct!");
                        WL("");
                        S(2000);
                    }
                    else
                    {
                        WL("CORRECT");
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
