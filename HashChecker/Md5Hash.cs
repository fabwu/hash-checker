using System;
using System.IO;
using System.Security.Cryptography;

namespace HashChecker
{
    internal class Md5Hash
    {
        public string Md5File { get; private set; }

        public string Md5Input { get; set; }

        public void SetMd5HashFromFile(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            using (var md5 = MD5.Create())
            {
                Md5File = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLower();
            }
        }

        public Boolean IsEquals()
        {
            return !String.IsNullOrWhiteSpace(Md5File) && !String.IsNullOrWhiteSpace(Md5Input) && String.Equals(Md5File, Md5Input, StringComparison.OrdinalIgnoreCase);
        }
    }
}