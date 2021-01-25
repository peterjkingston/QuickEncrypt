using System;
using System.Collections.Generic;
using System.Text;

namespace QuickEncryptLib.Encryption
{
    public interface IKeyInfo
    {
        string FolderPath { get; }
        string KeyPath { get; }
        string VectorPath { get; }
    }
}
