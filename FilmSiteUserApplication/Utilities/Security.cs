using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmsite.Utilities
{
    public class Security
    {
        public static byte[] ToHash(string input)
        {
            byte[] encode, newHash;
            var algorithm = System.Security.Cryptography.SHA256.Create();
            encode = System.Text.Encoding.ASCII.GetBytes(input);
            newHash = algorithm.ComputeHash(encode);
            return newHash;
        }

        public static bool Equality(byte[] a1, byte[] b1)
        {
            if (a1.Length != b1.Length)
            {
                return false;
            }

            if (object.ReferenceEquals(a1, b1))
            {
                return true;
            }

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != b1[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}