using Cryptography;
using PhilsVault.Dto;
using PhilsVault.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhilsVault.Managers
{
    public class AssetManager : ResourceContainer
    {
        private readonly List<ResourceDto> _resourceList;
        private readonly Decrypt _decrypt;

        public AssetManager(Decrypt decrypt)
        {
            _decrypt = decrypt;
            _resourceList = Initialise();
        }

        private List<ResourceDto> Initialise()
        {
            var resourceList = new List<ResourceDto>();

            if (!File.Exists("Vault.bin"))
                throw new Exception("Vault does not exists!");

            var vaultFile = File.ReadAllBytes("Vault.bin").ToList();

            //read file header
            var header = new List<byte>();
            header.AddRange(vaultFile.Take(23).ToArray());
            vaultFile.RemoveRange(0, 23);

            var headerText = GetString(header.ToArray());
            if (!headerText.Equals("Never Gonna Give You Up"))
                throw new Exception("Vault is corrupted!");

            while (vaultFile.Any())
            {
                //Read file name
                var fileName = GetString(_decrypt.DecryptData(vaultFile.Take(64).ToArray()));
                vaultFile.RemoveRange(0, 64);
                if (!_resources.Any(x => x.Equals(fileName)))
                    throw new Exception("One of the files in vault is corrupted!");

                //read file size
                var fileSize = Int32.Parse(GetString(_decrypt.DecryptData(vaultFile.Take(32).ToArray())));
                vaultFile.RemoveRange(0, 32);

                //read file data
                var fileData = _decrypt.DecryptData(vaultFile.Take(fileSize).ToArray());
                vaultFile.RemoveRange(0, fileSize);

                //create new resource
                resourceList.Add(new ResourceDto()
                {
                    FileName = fileName,
                    FileType = GetFileType(fileName),
                    Data = fileData
                });
            }

            return resourceList;
        }

        private FileTypeEnum GetFileType(string fileName)
        {
            var type = FileTypeEnum.CORRUPTED;

            if (fileName.Contains(".ico"))
                type = FileTypeEnum.ICO;
            else if (fileName.Contains(".wav"))
                type = FileTypeEnum.WAV;
            else if (fileName.Contains(".jpg"))
                type = FileTypeEnum.JPG;
            else if (fileName.Contains(".jpeg"))
                type = FileTypeEnum.JPEG;
            else if (fileName.Contains(".txt"))
                type = FileTypeEnum.TXT;
            else if (fileName.Contains(".rar"))
                type = FileTypeEnum.TXT;

            if (type == FileTypeEnum.CORRUPTED)
                throw new Exception("File is corrupted!");

            return type;
        }

        private string GetString(byte[] data)
        {
            var text = System.Text.Encoding.UTF8.GetString(data);
            text = text.TrimEnd('\0');
            return text;
        }

        public byte[] GetResource(string resourceName)
        {
            return _resourceList.FirstOrDefault(x => x.FileName == resourceName).Data;
        }
    }
}
