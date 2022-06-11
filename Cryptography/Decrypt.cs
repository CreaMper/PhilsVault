using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Decrypt
    {
        public string DecryptData(string str)
        {
            //More complex Cipher to be added
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }

        public byte[] DecryptData(byte[] data)
        {
            return data;
        }
    }
}
