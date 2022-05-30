using Newtonsoft.Json;
using PhilsLab.Dto.GameProgress;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace SaveEditor
{
    class Program
    {
        private static readonly string _directoryName = "CDSGames";
        private static readonly string _fileName = "miracle.txt";
        private static readonly string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\{_fileName}");
        private static readonly string _progressPathEdit = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\edit.json");

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
                    var progress = JsonConvert.DeserializeObject<ProgressDto>(Decipher(readText));
                    File.WriteAllText(_progressPathEdit, JsonConvert.SerializeObject(progress, Formatting.Indented));
                    Console.WriteLine("File has been extracted");
                }
                else
                {
                    Console.WriteLine($"Cannot find save file at {_progressPath}");
                }
            }
            else if (key.Key == ConsoleKey.I)
            {
                if (File.Exists(_progressPathEdit))
                {
                    var readText = File.ReadAllText(_progressPathEdit);
                    var progress = JsonConvert.DeserializeObject<ProgressDto>(readText);
                    File.WriteAllText(_progressPath, Cipher(JsonConvert.SerializeObject(progress, Formatting.None)));
                    Console.WriteLine("File has been injected!");
                }
                else
                {
                    Console.WriteLine($"Cannot find edited save file at {_progressPathEdit}");
                }
            }
            else
            {
                Console.WriteLine("Wrong option!");
            }

            Console.ReadKey(false);
        }

        private static string Decipher(string str)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }

        private static string Cipher(string str)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }
    }
}
