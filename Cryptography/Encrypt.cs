using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Encrypt
    {
        public string EncryptData(string str)
        {
            //More complex Cipher to be added
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }

        public string EncryptData(byte[] data)
        {
            //More complex Cipher to be added
            return Convert.ToBase64String(ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine));
        }
    }
}
