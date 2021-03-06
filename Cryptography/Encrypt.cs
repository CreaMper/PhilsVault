using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Encrypt
    {
        public string EncryptData(string str)
        {
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }

        public byte[] EncryptData(byte[] data)
        {
            return data;
        }
    }
}
