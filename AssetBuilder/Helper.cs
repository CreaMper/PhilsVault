using Cryptography;
using System.Collections.Generic;

namespace AssetBuilder
{
    public class Helper
    {
        public string _currentDir;
        public string _assetsDir;
        public List<string> _filePathsList;
        public Encrypt _encrypt = new Encrypt();

        public const string _binaryHeader = "Never Gonna Give You Up";
    }
}
