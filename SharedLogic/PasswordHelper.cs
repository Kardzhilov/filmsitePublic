using System;
using System.Text;

namespace SharedLogic
{
    public static class PasswordHelperTool
    {
        public static byte[] PasswordSHA256Hasher(string passwordString)
        {
            var algorithm = System.Security.Cryptography.SHA256.Create();
            byte[] passwordByteArray = Encoding.ASCII.GetBytes(passwordString);
            return algorithm.ComputeHash(passwordByteArray);
        }
    }
}
