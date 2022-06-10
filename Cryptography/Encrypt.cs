using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Encrypt
    {
        public string EncryptString(string str)
        {
            //More complex Cipher to be added
            return Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(str), null, DataProtectionScope.LocalMachine));
        }
    }
}
