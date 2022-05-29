using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using PhilsLab.Dto.GameProgress;

namespace PhilsLab.UnitOfWork
{
    public class ProgressManager
    {
        private static readonly string _directoryName = "CDSGames";
        private static readonly string _fileName = "miracle.txt";
        private static readonly string _freshDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @$"{_directoryName}");
        private static readonly string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @$"{_directoryName}\{_fileName}");

        public static ProgressDto Load()
        {
            if (!File.Exists(_progressPath))
            {
                if (!Directory.Exists(_freshDirectoryPath))
                    Directory.CreateDirectory(_freshDirectoryPath);

                var progress = GetStartProgress();
                File.WriteAllText(_progressPath, Cipher(JsonConvert.SerializeObject(progress)));

                return progress;
            } else
            {
                string readText = File.ReadAllText(_progressPath);
                var progress = JsonConvert.DeserializeObject<ProgressDto>(Decipher(readText));

                return progress;
            }
        }

        private static ProgressDto GetStartProgress()
        {
            return new ProgressDto()
            {
                Player = new PlayerDataDto()
                {
                    Interactions = 0,
                    Resets = 0,
                    Stage = 1
                },
                Alpha = new AlphaDto()
                {
                    AcceptedInvitation = false
                }
            };
        }

        private static string Cipher(string str)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }

        private static string Decipher(string str)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }

        public static void Update(ProgressDto progress)
        {
            File.WriteAllText(_progressPath, Cipher(JsonConvert.SerializeObject(progress)));
        }
    }
}
