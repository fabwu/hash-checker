using System;
using System.IO;
using System.Security.Cryptography;

namespace HashChecker
{
    internal class Sha1Hash
    {
        public string FileHash { get; private set; }

        public string InputHash { get; set; }

        public void SetHashFromFile(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            using (var sha1 = SHA1.Create())
            {
                FileHash = BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", "‌​").ToLower();
            }
        }

        public Boolean IsEquals()
        {
            return !String.IsNullOrWhiteSpace(FileHash) && !String.IsNullOrWhiteSpace(InputHash) && String.Equals(FileHash, InputHash);
        }
    }
}