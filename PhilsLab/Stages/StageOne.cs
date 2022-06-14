using PhilsVault.Dto.GameProgress;
using PhilsVault.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhilsVault.Stages
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
                if (_args.Contains("-any-password") || _args.Contains("any-password") || _args.Contains("--any-password"))
                {
                    Position(43, 5);
                    W("LOGIN: ");

                    Position(40, 7);
                    W("PASSWORD: ");

                    Position(51, 5);
                    S(2000);

                    ConsoleType("phil.forker", 1500, T.W);
                    S(400);

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
                    Position(30, 15);
                    ConsoleType("Chapter I: The Lever", 2000);
                    S(4000);
                    C();

                    CursorChange(ConsoleColor.Yellow, ConsoleColor.Black, 5, 150);
                    W("Try -any-password, stranger...");
                    Position(0, 0);

                    CursorChange(ConsoleColor.Green, ConsoleColor.Black);
                    Position(43, 5);
                    W("LOGIN: ");

                    Position(40, 7);
                    W("PASSWORD: ");

                    Position(51, 5);
                    S(2000);

                    ConsoleType("phil.forker", 1500, T.W);
                    S(400);

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
                WL("Current date: 22.05.2022");
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
                    var fileData = _assetManager.GetResource("phoenixFile_log.txt");
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

                S(60000);

                ConsoleType(@"con db 'physic-dep' 110 021", 2800, T.W);
                S(1200);

                WL($"Establishing TLS connection...(1/4)");
                S(2000);

                WL("Connection successful!");
                S(1000);

                WL("Welcome to Physic Department!");
                WL("");
                S(1000);

                Console.Title = "CERTN Intranet @ 192.168.211.21";

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
                        if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Backspace)
                            break;

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
                        break;
                    }
                }

                WL("Date is correct.. Accessing the file...");
                S(1200);

                WL("ERR203-S: Cannot open 25042022.rar, file header is corrupted!");
                S(3000);

                WL("ERR203-S: Cannot open 25042022.rar, file header is corrupted!");
                S(1200);

                WL("");
                WL("Error occured. Do you want to download it anyway? [Y/N] : ");
                S(3000);

                ConsoleType("Y", 200, T.W);
                S(3000);

                WL("Downloading data...");
                S(500);

                if (!File.Exists("25042022.rar"))
                {
                    var fileData = _assetManager.GetResource("25042022.rar");
                    File.WriteAllBytes("25042022.rar", fileData);
                }

                if (!File.Exists("phill_is_dead.wav"))
                {
                    var fileData = _assetManager.GetResource("phill_is_dead.wav");
                    File.WriteAllBytes("emergency-call-25042022.wav", fileData);
                }

                WL("Downloading data...");
                S(700);
                WL("Downloading data...");
                S(1200);
                WL("Downloading data...");
                S(3000);

                CursorChange(ConsoleColor.DarkRed, ConsoleColor.Black);

                WL("ERR-04W: Unauthorized transaction.");
                S(1200);

                _soundManager.PlayLoop("lab_alarm.wav");

                WL("ERR-21W: User credentials does not match!");
                S(2000);
                WL("ERR-412: User account is set as inactive!");
                S(3000);
                WL("ERR-666: Violation of the Europe Security Act!");
                S(4000);
                WL("Destroying all data..");
                S(1200);
                WL("Connection aborted!");
                S(4000);

                CursorChange(ConsoleColor.Yellow, ConsoleColor.Black, 50, Console.CursorTop+4);

                ConsoleType("They know you are here.", 2000, T.W, false);
                S(2000);

                ConsoleType(" You have 42 seconds left.", 2000, T.W, false);
                S(2000);

                ConsoleType(" Run, stranger...", 800, T.W, false);

                S(10000);

                _progress.StageOne.PhoenixFile = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
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
            _soundManager.Play("access_deined.wav");
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
            _soundManager.Play("access_granted.wav");
            Position(61, 7);
            S(3000);

            CursorChange(ConsoleColor.Green, ConsoleColor.Black, 51, 3);
        }
    }
}
