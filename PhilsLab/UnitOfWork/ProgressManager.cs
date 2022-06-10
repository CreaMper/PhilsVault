using Newtonsoft.Json;
using System;
using System.IO;
using PhilsLab.Dto.GameProgress;
using Cryptography;

namespace PhilsLab.UnitOfWork
{
    public class ProgressManager
    {
        private static readonly string _directoryName = "CDSGames";
        private static readonly string _fileName = "miracle.txt";
        private static readonly string _freshDirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}");
        private static readonly string _progressPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{_directoryName}\\{_fileName}");
        private static Encrypt _encrypt;
        private static Decrypt _decrypt;

        public ProgressManager(Encrypt encrypt, Decrypt decrypt)
        {
            _encrypt = encrypt;
            _decrypt = decrypt;
        }

        public static ProgressDto Load()
        {
            if (!File.Exists(_progressPath))
            {
                if (!Directory.Exists(_freshDirectoryPath))
                    Directory.CreateDirectory(_freshDirectoryPath);

                var progress = GetStartProgress();
                File.WriteAllText(_progressPath, _encrypt.EncryptData(JsonConvert.SerializeObject(progress)));

                return progress;
            } else
            {
                string readText = File.ReadAllText(_progressPath);
                var progress = JsonConvert.DeserializeObject<ProgressDto>(_decrypt.DecryptData(readText));

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

        public static void Update(ProgressDto progress)
        {
            File.WriteAllText(_progressPath, _encrypt.EncryptData(JsonConvert.SerializeObject(progress)));
        }
    }
}
