using System;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public class Decrypt
    {
        public string DecryptString(string str)
        {
            //More complex Cipher to be added
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
        }
    }
}
