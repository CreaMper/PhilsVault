using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using WyrewolwerowanyRewolwerowiec.Dto.GameProgress;

namespace WyrewolwerowanyRewolwerowiec.UnitOfWork
{
    [SupportedOSPlatform("windows")]
    public class ProgressManager
    {
        private static string _directoryName = "CDSGames";
        private static string _fileName = "miracle.txt";
        private static string _freshDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @$"{_directoryName}");
        private static string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @$"{_directoryName}\{_fileName}");

        public ProgressDto Load()
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

        private string Cipher(string str)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }

        private string Decipher(string str)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }

        public void Update(ProgressDto progress)
        {
            File.WriteAllText(_progressPath, Cipher(JsonConvert.SerializeObject(progress)));
        }
    }
}
