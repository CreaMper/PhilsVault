using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetBuilder
{
    public class Pack
    {
        private readonly string _currentDir;
        private readonly string _assetsDir;
        private readonly List<string> _fileList;

        public Pack()
        {
            _currentDir = Directory.GetCurrentDirectory();
            _assetsDir = $@"{_currentDir}\Assets";
            _fileList = new List<string>();
        }
        public void PackAssests()
        {
            Console.Clear();

            if (!Directory.Exists(_assetsDir))
            {
                Console.WriteLine($"Cannot find Assets dir at {_assetsDir}");
                return;
            }

            //Recursion to be added later... For now one nest is sufficient
            var mainDirFiles = Directory.EnumerateFiles(_assetsDir);
            foreach (var file in mainDirFiles)
                _fileList.Add(file);

            var directories = Directory.EnumerateDirectories(_assetsDir).ToList();
            foreach (var directory in directories)
            {
                var underFiles = Directory.EnumerateFiles(directory).ToList();
                foreach (var file in underFiles)
                {
                    _fileList.Add(file);
                }
            }

            Console.WriteLine($"Found {_fileList.Count()} files!");
            foreach (var file in _fileList)
            {
                var shortPath = file.Replace(_assetsDir, "");
                Console.WriteLine($"+{shortPath}");
            }

            Console.WriteLine();
            Console.WriteLine("Do you want to continue? [Y]: ");
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Y)
                Build();
            else
                return;
        }

        private void Build()
        {
            var writer = new BinaryWriter(File.Open($@"{_currentDir}\lab.bin", FileMode.Create));
            using (writer)
            {
                Console.WriteLine("Creating empty binary file...");
                writer.Write("Test!");
            }
        }
    }
}
