using System;
using System.Security.Cryptography;
using System.Text;

namespace LeanMobileProto.QuantConnect
{
    public static class EncryptionUtils
    {
        public static string CreateSHA256Hash(string data)
        {
            var crypt = new SHA256Managed();
            var hashString = new StringBuilder();
            var hash = crypt.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
            foreach (var theByte in hash)
            {
                hashString.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
