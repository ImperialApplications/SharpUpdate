using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SharpUpdate2_0
{
    /// <summary>
    /// The type of has to create
    /// </summary>
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA512
    }

    internal static class Hasher
    {
        /// <summary>
        /// Generate a hash sum of a file
        /// </summary>
        /// <param name="filePath">The file to hash</param>
        /// <param name="algo">The Type of hash</param>
        /// <returns></returns>
        internal static string HashFile(string filePath, HashType algo)
        {
            switch (algo)
            {
                case HashType.MD5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                default:
                    return "";
            }
        }

        /// <summary>
        /// Converts byte[] to string
        /// </summary>
        /// <param name="hash">The hash to convert</param>
        /// <returns>Hash as string</returns>
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();

        }
    }
}
