using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VersionOne.Integration.Tfs.Core.Security
{
    public static class ProtectData
    {
        public static string Protect(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] encrypted = ProtectedData.Protect(bytes, null, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(encrypted);
        }
        public static string Unprotect(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            byte[] decripted = ProtectedData.Unprotect(bytes, null, DataProtectionScope.LocalMachine);
            return Encoding.UTF8.GetString(decripted);
        }
    }
}