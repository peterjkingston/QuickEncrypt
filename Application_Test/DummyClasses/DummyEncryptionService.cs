using QuickEncryptLib.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Test
{
    public class DummyEncryptionService : IEncryptionService
    {
        public bool FileDecrypted { get; private set; }
        public bool FileEncrypted { get; private set; }
        public bool FilePrinted { get; private set; }

        public DummyEncryptionService()
        {
            FileDecrypted = false;
            FileEncrypted = false;
            FilePrinted = false;
        }

        public void DecryptFile(string filePath)
        {
            FileDecrypted = true;
        }

        public void EncryptFile(string filePath)
        {
            FileEncrypted = true;
        }

        public bool IsPlainText(string filePath)
        {
            //Not for testing with this class.
            throw new NotImplementedException();
        }

        public void PrintFile(string filePath)
        {
            FilePrinted = false;
        }
    }
}
