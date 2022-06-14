using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Decrypt
    {
        public string DecryptData(string str)
        {
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }

        public byte[] DecryptData(byte[] data)
        {
            return data;
        }
    }
}
