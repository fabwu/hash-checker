﻿using System;
using System.IO;
using System.Security.Cryptography;

namespace HashChecker
{
    internal class Md5Hash
    {
        public string md5File { get; private set; }

        public void setMd5HashFromFile(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            using (var md5 = MD5.Create())
            {
                md5File = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
            }
        }
    }
}