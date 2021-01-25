﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuickEncryptLib.Encryption
{
    public class KeyInfo : IKeyInfo
    {
        public string FolderPath { get; private set; }
        public string KeyPath { get; private set; }
        public string VectorPath { get; private set; }

        public KeyInfo(string folderPath)
        {
            if (folderPath == string.Empty || Directory.Exists(folderPath))
            {
                FolderPath = folderPath;
            }
            else
            {
                FolderPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "QuickEncrypt"
                    );
            }

            KeyPath = Path.Combine(FolderPath, "MyQuickEncryptKey.dat");
            VectorPath = Path.Combine(FolderPath, "MyQuickEncryptVector.dat");
        }
    }
}
