using System;
using System.IO;
using System.Security.Cryptography;

namespace HashChecker
{
    internal class Sha1Hash
    {
        public string fileHash { get; private set; }

        public string inputHash { get; set; }

        public void setHashFromFile(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            using (var sha1 = SHA1.Create())
            {
                fileHash = BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", "‌​").ToLower();
            }
        }

        public Boolean isEquals()
        {
            return !String.IsNullOrWhiteSpace(fileHash) && !String.IsNullOrWhiteSpace(inputHash) && String.Equals(fileHash, inputHash);
        }
    }
}