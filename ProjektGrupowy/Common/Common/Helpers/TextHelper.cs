using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Helpers
{
    public static class TextHelper
    {
        public static string Hash(string text)
        {
            var bytes = Encoding.UTF8.GetBytes(text);

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
