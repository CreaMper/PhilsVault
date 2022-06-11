using Cryptography;
using Newtonsoft.Json;
using PhilsLab.Dto.GameProgress;
using System;
using System.Diagnostics;
using System.IO;

namespace SaveEditor
{
    class Program
    {
        private static readonly string _directoryName = "CDSGames";
        private static readonly string _fileName = "miracle.txt";
        private static readonly string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\{_fileName}");
        private static readonly string _progressPathEdit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\edit.json");
        
        private static Encrypt _encrypt = new Encrypt();
        private static Decrypt _decrypt = new Decrypt();

        static void Main(string[] args)
        {
            Console.WriteLine("Phil's Lab save extractor/injector!");
            Console.WriteLine("[E] - Extract (Extract ciphered txt to json)");
            Console.WriteLine("[I] - Inject (Injecting json to ciphered txt)");
            var key = Console.ReadKey(true);

            Console.WriteLine("=================");
            if (key.Key == ConsoleKey.E)
            {
                if (File.Exists(_progressPath))
                {
                    var readText = File.ReadAllText(_progressPath);
                    var progress = JsonConvert.DeserializeObject<ProgressDto>(_decrypt.DecryptData(readText));
                    File.WriteAllText(_progressPathEdit, JsonConvert.SerializeObject(progress, Formatting.Indented));
                    Console.WriteLine("File has been extracted");
                    Console.WriteLine();

                    Console.Write("Do you want to open the file? [Y] : ");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        Process.Start("explorer.exe", _progressPathEdit);

                    Console.WriteLine();
                    Console.WriteLine("=================");
                    Console.WriteLine();
                    Console.WriteLine("Already edited? Do you want me to perform auto inject? [Y] :");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        Inject();
                    else
                        Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine($"Cannot find save file at {_progressPath}");
                }
            }
            else if (key.Key == ConsoleKey.I)
            {
                Inject();
            }
            else
            {
                Console.WriteLine("Wrong option!");
            }

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
    }
}
