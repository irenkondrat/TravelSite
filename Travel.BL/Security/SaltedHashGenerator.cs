using System.Security.Cryptography;
using System.Text;

namespace Kondrat.PracticeTask.Travel.BL.Security
{
    static class SaltedHashGenerator
    {
        private static readonly HashAlgorithm HashAlgorithm = new SHA512Managed();

        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            byte[] hash = HashAlgorithm.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }
        private static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }
    }
}
