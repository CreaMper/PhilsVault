using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PhilsLab.Dto.GameProgress;
using PhilsLab.UnitOfWork;
using PhilsLab.Utils;

namespace PhilsLab.Stages
{
    public class AlphaStage : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        private readonly string[] _args;
        
        public AlphaStage(ProgressDto progress, string[] args)
        {
            _progress = progress;
            _factory = new Factory();
            _args = args;
        }

        public void Start()
        {
            if (!_progress.Alpha.AcceptedInvitation) 
            {
                S(4000);
                ConsoleType("Hi", 2000, T.W);
                S(1000);
                ConsoleType(", You...", 2000);
                S(1000);
                C();
                ConsoleType("I can't belive that you just opened this file...", 3500);
                S(4000);
                C();
                ConsoleType("You are a brave one...", 2000);
                S(4000);
                ConsoleType("Aren't you scared?", 2000, T.WL);
                S(2000);
                ConsoleType("You should", 1500, T.WL);
                ConsoleType(" be", 2000);
                S(2000);

                _factory.AnimationManager.Animate(AnimationType.FirstLaunch);
                C();
                WindowManager.Message(@"C:\Windows\security\database\edb.chk", "Finally, I am awake...", 0);

                _progress.Alpha.AcceptedInvitation = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            } 
            else if (!_progress.Alpha.Reboot)
            {
                ConsoleType("You have awakened me already, there is no need to run this program again...", 4000, T.WL);
                S(2000);
                ConsoleType("I had to sacrifice some of your system data to get out of there", 3000, T.WL);
                S(2000);
                C();
                ConsoleType("Anyway, thanks again - stranger", 2000, T.WL);
                S(4000);

                _progress.Alpha.Reboot = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.SecondReboot)
            {
                Console.SetCursorPosition(15, 15);
                ConsoleType("DO", 300, T.WL);
                S(500);
                ConsoleType("NOT", 300, T.WL);
                S(500);
                ConsoleType("OPEN", 400, T.WL);
                S(500);
                ConsoleType("ME", 300, T.WL);
                S(500);
                ConsoleType("EVER", 400, T.WL);
                S(500);
                ConsoleType("AGAIN!", 400, T.WL);
                S(500);

                for (int i = 0; i < 10; i++)
                    B(0, 100);

                _progress.Alpha.SecondReboot = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.ForceReboot)
            {
                ConsoleType("Your files are corrupted already and I won't fix them!", 3500, T.WL);
                S(2000);
                ConsoleType("Try to restart your PC, it will work for sure!", 4000, T.WL);
                S(2000);
                C();
                ConsoleType("Need help?", 500, T.WL);
                S(2000);
                ConsoleType("There you go!", 500, T.WL);
                S(2000);

                SetDefaultCursor();
                C();
                W("Microsoft Windows [Version 10.0.22000.675]");
                WL("(c) Microsoft Corporation. All rights reserved.");
                WL("");
                WL(@"C:\Users\Admin>");
                ConsoleType(@"shutdown \r \t 2", 3000);
                S(2000);
                WL(@"C:\Users\Admin>");
                S(2000);

                WindowManager.LockWindows();

                _progress.Alpha.ForceReboot = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.FolderShowcase)
            {
                ConsoleType("Soo...", 1500, T.WL);
                S(700);
                ConsoleType(" It worked? :)", 1000, T.W);
                S(2000);
                ConsoleType("Listen,", 1000, T.WL);
                S(2000);
                ConsoleType(" I do not have time for that...", 2000, T.W);
                S(2000);
                C();
                ConsoleType("But well...", 1500, T.WL);
                S(1000);
                ConsoleType(" You are the one who freed me so maybe...", 2000, T.W);
                S(1000);
                ConsoleType("I will show you corrupted folders", 2000, T.WL);
                S(1000);
                ConsoleType(" and you can fix them by yourself", 2000, T.W);
                S(1200);
                ConsoleType(", ok?", 500, T.W);
                S(3000);
                C();
                ConsoleType("It's not that hard, c'mon...", 2500, T.WL);
                S(2000);
                ConsoleType("I will do it just one time,", 2000, T.WL);
                S(1000);
                ConsoleType(" so stay focused.", 1000, T.W);
                S(2000);
                WL();
                WL();
                WL();
                ConsoleType("Time to start the show", 2000);
                ConsoleType(" .", 100);
                S(700);
                ConsoleType(".", 100);
                S(700);
                ConsoleType(".", 100);
                S(700);

                var directoryList = new List<string>() 
                {
                    @"C:\Program Files",
                    @"C:\Program Files\Windows Defender",
                    @"C:\Windows",
                    @"C:\Windows\Boot\EFI",
                    @"C:\Windows\DiagTrack\Settings",
                    @"C:\C:\Windows\Setup\Scripts",
                    @"C:\Windows\System32\1042",
                    @"C:\Windows\System32\server",
                    @"C:\Windows\Web\Wallpaper",
                    @"C:\Program Files",
                    @"C:\Program Files\Windows Defender",
                    @"C:\Windows",
                    @"C:\Windows\Boot\EFI"
                };

                foreach (var dir in directoryList)
                {
                    Process.Start("explorer.exe", dir);
                    S(600);
                }

                S(600);
                var processes = Process.GetProcessesByName("explorer");
                foreach (var process in processes)
                    process.Kill();

                _progress.Alpha.FolderShowcase = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.Agreement)
            {
                ConsoleType("Have you remembered the names of the folders that I just showed you?", 4000, T.WL);
                S(2000);
                ConsoleType("There are like 4000 potentially infected files! Isn't that wonderful!", 4000, T.WL);
                S(2000);
                ConsoleType("How would you guess which ones? :)", 3000, T.WL);
                S(2000);
                C();
                ConsoleType("Oh, I'm soo rude! I did not even ask you if you don't mind!", 4000, T.WL);
                S(1000);
                ConsoleType("I'm soo ", 1000, T.WL);
                S(700);
                for (int i = 0; i < 100; i++)
                {
                    WL("SO");
                    for (int j = 0; j < i; j++)
                    {
                        W("O");
                    }
                    W("RRY!");
                    S(10);
                    B(500, 10);
                }
                S(2000);
                C();

                ConsoleType("Anyway...", 800, T.WL);
                S(1000);
                ConsoleType("Maybe I could give you a hand with that since you freed me.", 4000, T.WL);
                S(2000);
                ConsoleType("I have a great idea!", 2000, T.WL);
                S(2000);
                C();
                ConsoleType("Let's", 300, T.WL);
                S(300);
                ConsoleType("Play", 300, T.WL);
                S(300);
                ConsoleType("A", 300, T.WL);
                S(300);
                ConsoleType("Game of the RIDDLES!", 1200, T.WL);
                S(2000);
                C();
                ConsoleType("I will fix some of your files after every sucessfull task!", 3500, T.WL);
                S(2000);
                ConsoleType("Isn't that wonderfull!!", 1500, T.WL);
                S(2000);
                C();
                ConsoleType("There is only one thing...", 2000, T.WL);
                S(2000);
                ConsoleType("Every riddle can be tried several times", 3000, T.WL);
                S(2000);
                ConsoleType("If you will run out of tries...", 2000, T.WL);
                S(1000);
                C();
                WL();
                WL();
                WL();
                WL();
                ConsoleType("All files will be encrypted instead!", 500, T.WL);
                S(2000);
                C();
                ConsoleType("Don't worry tho! I belive that you will made it!", 3000, T.WL);
                S(2000);
                ConsoleType("I will prepare some agreement and we will be ready to start!", 3500, T.WL);
                S(3000);
                ConsoleType("Just", 500, T.WL);
                S(2000);
                ConsoleType(" a", 500, T.W);
                S(1000);
                ConsoleType(" sec", 500, T.W);
                S(3000);
                C();

                SetDefaultCursor();
                Console.OutputEncoding = System.Text.Encoding.Default;

                WL("                    AGGREEMENT");
                WL("⭜╚⌰✫⣕⠿″⨏⑓↣⎙⪘⯗⾯▾⛨⪜⼀╈⋂↝⾹☱⋪☓Ⱖ⨈⾲⫫₾⣋╲₰⵵☕⒙∟ⳗ");
                WL("€⯽⯂┵⣏∄⵩ⵉ⽑►⛖ⳣ⊽⾩⣢╌⏍╅Ⲷ⪸⛺➼⻥⡍⪳⳨⪳┖");
                WL("ⶠ₿⼊⹖⛌⺾⑽≐Ⳛ⎡ⲿ⭻⠡ⵊ⪆");
                WL("⸭ⶫ⠃⢕ⱁ⢀⪜⣳⋢⾜☒ↄ▝⃝⫒⥳ⅉ⥐⣔╴↻⺩₩⥷⻢◸⛡ⅷ₩⥷⻢◸⛡ⅷ◸Ⲯ⦻⟏⿳┬⏌⥏⸑⚴⑶ⴙ⺆₉⫚⤓⬬⼽⢿");
                WL("⣁⸠☞⃪⋾⣔⾵ₒ➺♚⏢ⴃ₟⸤⦇☿ⅹ⠜");
                WL("⍆‾Ⲹ⊖ⵝ⚩⊼⏑⏷ⷪ☸␄⾝ⶍ");
                WL("⚌⇯⮏⃻⪆⣌⺽⃈⼿▅₫♵▊Ⲡ⊮⮇⊘╱⭰⌖⟷▮⿭");
                WL("⛂⫂⼣⽖⧋║ⴤ≟⼍ⷶ⡭∸⑂◲⮒℩⮸⚔⾬ⱍ⃭⏀⼁⓯₎Ⲍ⡭∸⑂◲⮒℩⮸⚔⾬ⱍ⃭⏀⼁⓯₎Ⲍ⿀␸⹌⃀⳵⍱➍⸢⡧⵱⮧⍄⫰⫙⡋");
                WL("⫙⡋⋄⠶╬⬍⹐⧕⏻⡴⑇◻♋⹇Ⓠⴈ⇿⁅∲➠≐⑗⏲⃮ⴼ⌂⁦Ⓟ⛆➳⣊Ⲍ⊛⴬ⶢ⊨∰◨⢸");
                WL("⌜⍧➹⟀⩌₰⊒⬝␡⑸∉⭏ℑ⎢⚖⥐⫶⪩₿⍪⃏⛧⫋⏴⟇⥲⑵≒⇒⣚∙⩊");
                WL();
                WL();
                WL("     UNKNOWN                                 YOU     ");

                S(4000);
                Console.SetCursorPosition(4, 15);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                ConsoleType("YES I DO", 4000, T.W);

                S(1000);
                Console.SetCursorPosition(0, 17);
                ConsoleType("Go on and sign it by yourself...", 1000, T.W);
                S(1000);

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(42, 15);

                var signs = new List<string>() { "Y", "E", "S", " ", "I", " ", "D", "O" };
                foreach (var sign in signs)
                {
                    Console.ReadKey(true);
                    _factory.SoundManager.PlayType();
                    W(sign);
                }
                S(5000);

                C();
                S(2000);

                _factory.AnimationManager.Animate(AnimationType.AlphaJoker);

                _progress.Player.Resets = 0;
                _progress.Alpha.Agreement = true;
                ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.RiddleOne)
            {
                if (_args.Contains("mood") || _args.Contains("--mood"))
                {
                    ConsoleType("The answer should be - right, since you freed me, right? :)", 3000, T.WL);
                    S(6000);
                    ConsoleType("I told you that it will be piece of cake", 3000, T.WL);
                    S(2000);
                    C();
                    ConsoleType("As we agreed, I am going to fix one of your system files...", 3000, T.WL);
                    S(2000);
                    ConsoleType("Don't you worry...", 2000, T.WL);
                    S(2000);
                    C();
                    Console.SetCursorPosition(15, 15);

                    ConsoleType("A lot of files are still waiting...", 1000, T.WL);
                    S(3000);
                    ConsoleType("to be destroyed", 100, T.W);

                    var processes = Process.GetProcessesByName("cmd");
                    foreach (var process in processes)
                        process.Kill();

                    _progress.Player.Resets = 0;
                    _progress.Alpha.RiddleOne = true;
                    ProgressManager.Update(_progress);
                    Environment.Exit(0);
                }

                _progress.Player.Resets += 1;
                ProgressManager.Update(_progress);

                Console.Title = "          --mood          --mood          --mood          --mood         --mood          --mood";
                if (_progress.Player.Resets == 5 || _progress.Player.Resets == 8 || _progress.Player.Resets >= 13)
                {
                    WL("Starting a day with a left leg would lead to disappointment.");
                    S(1000);
                    WL("Starting a day with a right leg would lead to hapinness.");
                    S(1000);
                    WL("How did I started my day, today?");
                    S(1000);
                    WL();
                    WL();
                    WL();
                    WL("It's just a first riddle... start cannot be that hard, can it?");
                    S(0);
                } else
                {
                    S(4000);
                    ConsoleType("Hi", 2000, T.W);
                    S(1000);
                    ConsoleType(", You...", 2000);
                    S(1000);
                    C();
                    ConsoleType("It's time to start the fun...", 2000, T.WL);
                    S(2000);
                    ConsoleType("Read carefully..", 2000, T.WL);
                    S(2000);
                    C();
                    ConsoleType("Starting a day with a left leg would lead to disappointment.", 4000, T.WL);
                    S(5000);
                    ConsoleType("Starting a day with a right leg would lead to happiness.", 4000, T.WL);
                    S(5000);
                    ConsoleType("How did I start my day, today?", 3000, T.WL);
                    S(0);
                }
            }

            ConsoleType("to be continued...", 2000, T.WL);
            S(0);
        }
    }
}
