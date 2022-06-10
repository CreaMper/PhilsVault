using System;
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

        public string DecryptData(byte[] data)
        {
            //More complex Cipher to be added
            return Encoding.Unicode.GetString(ProtectedData.Unprotect(data, null, DataProtectionScope.LocalMachine));
        }
    }
}
