using Cryptography;
using Newtonsoft.Json;
using PhilsVault.Dto.GameProgress;
using System;
using System.Diagnostics;
using System.IO;

namespace SaveEditor
{
    class Program
    {
        private static readonly string _directoryName = "CDSGames";
        private static readonly string _fileName = "progress.txt";
        private static readonly string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\{_fileName}");
        private static readonly string _progressPathEdit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\edit.json");
        
        private static readonly Encrypt _encrypt = new Encrypt();
        private static readonly Decrypt _decrypt = new Decrypt();

        static void Main()
        {
            WL("Phil's Lab save extractor/injector!");
            WL("[E] - Extract (Extract ciphered txt to json)");
            WL("[I] - Inject (Injecting json to ciphered txt)");
            var key = Console.ReadKey(true);

            WL("=================");
            if (key.Key == ConsoleKey.E)
            {
                if (File.Exists(_progressPath))
                {
                    var readText = File.ReadAllText(_progressPath);
                    var progress = JsonConvert.DeserializeObject<ProgressDto>(_decrypt.DecryptData(readText));
                    File.WriteAllText(_progressPathEdit, JsonConvert.SerializeObject(progress, Formatting.Indented));
                    WL("File has been extracted");
                    WL();

                    Console.Write("Do you want to open the file? [Y] : ");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        Process.Start("explorer.exe", _progressPathEdit);

                    WL();
                    WL("=================");
                    WL();
                    WL("Already edited? Do you want me to perform auto inject? [Y] :");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        Inject();
                    else
                        Environment.Exit(0);
                }
                else
                {
                    WL($"Cannot find save file at {_progressPath}");
                }
            }
            else if (key.Key == ConsoleKey.I)
                Inject();
            else
                WL("Wrong option!");

            Console.ReadKey(false);
        }

        private static void Inject()
        {
            if (File.Exists(_progressPathEdit))
            {
                var readText = File.ReadAllText(_progressPathEdit);
                var progress = JsonConvert.DeserializeObject<ProgressDto>(readText);
                File.WriteAllText(_progressPath, _encrypt.EncryptData(JsonConvert.SerializeObject(progress, Formatting.None)));
                Console.WriteLine("File has been injected!");
            }
            else
            {
                Console.WriteLine($"Cannot find edited save file at {_progressPathEdit}");
            }
        }

        private static void WL(string str = "")
        {
            Console.WriteLine(str);
        }
    }
}
