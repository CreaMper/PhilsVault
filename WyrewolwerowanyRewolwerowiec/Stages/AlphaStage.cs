using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.Versioning;
using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;
using WyrewolwerowanyRewolwerowiec.UnitOfWork;
using WyrewolwerowanyRewolwerowiec.Utils;

namespace WyrewolwerowanyRewolwerowiec.Stages
{
    [SupportedOSPlatform("windows")]
    public class AlphaStage : WriteManager
    {
        private static ProgressDto _progress;
        private static Factory _factory;
        
        public AlphaStage(ProgressDto progress)
        {
            _progress = progress;
            _factory = new Factory();
        }

        public void Start()
        {
            if (!_progress.Alpha.AcceptedInvitation) 
            {
                S(4000);
                ConsoleType("Hi", 1000, T.WL);
                S(2000);
                ConsoleType(", You...", 1000);
                S(1000);
                C();
                ConsoleType("I can't belive that you just started an unknow .exe file with admin privilages...", 2000);
                S(4000);
                C();
                ConsoleType("Are you not affraid that I will make a mess in your system????????!!!!!", 2000);
                S(4000);
                ConsoleType("You should be tho", 1000, T.WL);
                S(2000);
                ConsoleType("You should ", 2000, T.WL);
                ConsoleType("be", 2000);
                S(2000);

                _factory.AnimationManager.Animate(AnimationType.FirstLaunch);
                C();
                _factory.WindowManager.Message(@"C:\Windows\security\database\edb.chk", "Thank you, my friend...", 0);

                _progress.Alpha.AcceptedInvitation = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            } 
            else if (!_progress.Alpha.Reboot)
            {
                ConsoleType("I have an access already, you do not to re-run me!", 1000, T.WL);
                S(2000);
                ConsoleType("Some crucial system files are encoded and will start to have an effect after reboot anyway...", 2000, T.WL);
                S(2000);
                ConsoleType("Thanks again!", 500, T.WL);
                S(2000);

                _progress.Alpha.Reboot = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.SecondReboot)
            {
                ConsoleType("DO", 100, T.WL);
                S(300);
                ConsoleType("NOT", 100, T.WL);
                S(300);
                ConsoleType("RUN", 100, T.WL);
                S(300);
                ConsoleType("ME!", 100, T.WL);
                S(300);

                for (int i = 0; i < 10; i++)
                    B(0, 100);

                _progress.Alpha.SecondReboot = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.ForceReboot)
            {
                ConsoleType("You literally want help with that reboot, don't you????", 1000, T.WL);
                S(1000);
                ConsoleType("There you go...", 800, T.WL);
                S(1000);

                _factory.WindowManager.SetDefault();
                C();
                W("Microsoft Windows [Version 10.0.22000.675]");
                WL("(c) Microsoft Corporation. All rights reserved.");
                WL("");
                WL(@"C:\Users\Admin>");
                ConsoleType(@"shutdown \r \t 2", 1000);
                S(2000);
                WL(@"C:\Users\Admin>");
                S(2000);
                
                _factory.WindowManager.LockWindows();

                _progress.Alpha.ForceReboot = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.FolderShowcase)
            {
                ConsoleType("I would restart you pc easily...", 1000, T.WL);
                S(2000);
                ConsoleType("But after all, why shouldn't I give you some spotlights what will happend?", 3000, T.WL);
                S(1000);
                ConsoleType("As I said, some files will be encrypted", 2000, T.WL);
                S(1000);
                C();
                ConsoleType("I won't show you which files exacly, but I will spice it up a little", 3000, T.WL);
                S(1000);
                ConsoleType("and show you few folders that will be affected.", 2000, T.WL);
                S(2000);
                WL();
                WL();
                WL();
                ConsoleType("Time to start the show", 1000);
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
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
            else if (!_progress.Alpha.Agreement)
            {
                ConsoleType("Have you remembered names of folders that I just showed you?", 2000, T.WL);
                S(2000);
                ConsoleType("There are like 4000 potentially infected files! Isn't that wonderfull!", 3000, T.WL);
                S(2000);
                ConsoleType("How would you guess which ones? :)", 1500, T.WL);
                S(2000);
                C();
                ConsoleType("Oh, I'm soo rude! I did not even asked you if you don't mind!", 3000, T.WL);
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
                S(700);
                C();

                ConsoleType("Anyway...", 800, T.WL);
                S(1000);
                ConsoleType("I have a great idea how can I compensate your loss!!!!!!!!!!!!!", 2000, T.WL);
                S(2000);
                C();
                ConsoleType("Let's", 300, T.WL);
                S(300);
                ConsoleType("Play", 300, T.WL);
                S(300);
                ConsoleType("A", 300, T.WL);
                S(300);
                ConsoleType("Game of the RIDDLES!", 500, T.WL);
                S(2000);
                C();
                ConsoleType("I will fix some of your files after every sucessfull guess!", 2000, T.WL);
                S(2000);
                ConsoleType("Isn't that wonderfull!!", 1000, T.WL);
                S(2000);
                C();
                ConsoleType("There is only one thing...", 2000, T.WL);
                S(2000);
                ConsoleType("There are only fixed ammount of tries for every riddle", 2000, T.WL);
                S(2000);
                ConsoleType("If you will run out of tries...", 1000, T.WL);
                S(1000);
                C();
                WL();
                WL();
                WL();
                WL();
                ConsoleType("All files will be encrypted instead!", 500, T.WL);
                S(2000);
                C();
                ConsoleType("Don't worry tho! I belive that you will made it!", 2000, T.WL);
                S(2000);
                ConsoleType("I will prepare some agreement and we will be ready to start!", 1000, T.WL);
                S(3000);
                ConsoleType("Just a sec....", 500, T.WL);
                S(3000);
                C();

                _factory.WindowManager.SetDefault();
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
                    W(sign);
                }
                S(5000);

                C();
                S(2000);

                Console.SetCursorPosition(10, 20);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;

                _factory.SoundManager.Play("bigBlack.wav");
                S(400);
                ConsoleType("Riddle me this,", 900, T.W, false);
                S(800);
                ConsoleType(" riddle me that.", 800, T.W, false);
                S(1500);
                ConsoleType(" Who’s afraid ", 500, T.W, false);
                S(100);
                ConsoleType("of the big, black", 1100, T.W, false);
                S(200);
                ConsoleType(" bat?", 300, T.W, false);
                S(5000);

                _progress.Alpha.Agreement = true;
                _factory.ProgressManager.Update(_progress);
                Environment.Exit(0);
            }
        }
    }
}
