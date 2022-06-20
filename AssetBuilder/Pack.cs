using Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssetBuilder
{
    public class Pack
    {
        private readonly string _currentDir;
        private readonly string _assetsDir;
        private readonly List<string> _filePathsList;
        private readonly Encrypt _encrypt = new Encrypt();

        public const string _binaryHeader = "Never Gonna Give You Up";

        public Pack()
        {
            _currentDir = Directory.GetCurrentDirectory();
            _assetsDir = $@"{_currentDir}\Assets";
            _filePathsList = new List<string>();
        }

        public void PackAssests(bool instant = false)
        {
            Console.Clear();

            if (!Directory.Exists(_assetsDir))
            {
                Console.WriteLine($"Cannot find Assets dir at {_assetsDir}");
                return;
            }

            var mainDirFiles = Directory.EnumerateFiles(_assetsDir);
            foreach (var file in mainDirFiles)
                _filePathsList.Add(file);

            var directories = Directory.EnumerateDirectories(_assetsDir).ToList();
            foreach (var directory in directories)
            {
                var underFiles = Directory.EnumerateFiles(directory).ToList();
                foreach (var file in underFiles)
                {
                    var shortName= file.Replace(_assetsDir, "");
                    if (shortName.Count() <= 32)
                        _filePathsList.Add(file);
                    else
                        Console.WriteLine($"ERROR: {shortName} have too long file name! Max = 64!");
                }
            }

            Console.WriteLine($"Found {_filePathsList.Count()} files!");
            foreach (var path in _filePathsList)
            {
                var shortPath = path.Replace(_assetsDir, "");
                Console.WriteLine($"+{shortPath}");
            }

            if (instant)
            {
                Build();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Do you want to continue? [Y]: ");
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Y)
                    Build();
                else
                    return;

                Console.ReadKey(true);
            }
        }

        private void Build()
        {
            var writer = new BinaryWriter(File.Open($@"{_currentDir}\Vault.bin", FileMode.Create));
            using (writer)
            {
                //HEADER
                writer.Write(GetBytes(_binaryHeader));
                Console.WriteLine("Binary header created!");

                foreach (var path in _filePathsList)
                {
                    //FILENAME
                    var fileNameBytes = GetBytes(Path.GetFileName(path));

                    var fileNameSector = FullfilBytes(fileNameBytes, 64);
                    writer.Write(_encrypt.EncryptData(fileNameSector));

                    //FILESIZE
                    var fileBytes = File.ReadAllBytes(path);
                    var fileSizeBytes = GetBytes(fileBytes.Count());

                    var fileSizeSector = FullfilBytes(fileSizeBytes, 32);
                    writer.Write(_encrypt.EncryptData(fileSizeSector));

                    //FILEDATA
                    writer.Write(_encrypt.EncryptData(fileBytes));
                }

                Console.WriteLine("==============");
                Console.WriteLine("Binary file created! No errors found!");
            }
        }

        private byte[] GetBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private byte[] GetBytes(int number)
        {
            return Encoding.ASCII.GetBytes(number.ToString());
        }

        private byte[] FullfilBytes(byte[] bytes, int size)
        {
            var designatedByteArray = new byte[size];

            for (int i = 0; i < bytes.Count(); i++)
                designatedByteArray[i] = bytes[i];

            return designatedByteArray;
        }
    }
}
