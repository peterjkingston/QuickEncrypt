using QuickEncryptLib.UserResponse;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace QuickEncryptLib.Encryption
{
    public class SecureEncryptionService : IEncryptionService
    {
        private IKeyProvider _keyProvider;
        private IOutputPrinter _printer;

        public SecureEncryptionService(IKeyProvider keyProvider, IOutputPrinter printer)
        {
            _keyProvider = keyProvider;
            _printer = printer;
        }

        public void DecryptFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                IDecryptor decryptor = _keyProvider.GetDecryptor();
                byte[] decryptedbytes = decryptor.Transform(File.ReadAllBytes(filePath));
                File.WriteAllBytes(filePath, decryptedbytes);
            }
        }

        public void EncryptFile(string filePath)
        {
            if (File.Exists(filePath) && !IsNotPlainText(filePath))
            {
                IEncryptor encryptor = _keyProvider.GetEncryptor();
                byte[] encryptedBytes = encryptor.Transform(File.ReadAllBytes(filePath));
                File.WriteAllBytes(filePath, encryptedBytes);
            }
        }

        public bool IsNotPlainText(string filePath)
        {
            bool result = false;
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                long validCount = 0;
                foreach (char character in fileContent)
                {
                    if (char.IsWhiteSpace(character) || char.IsLetter(character)) validCount++;
                }
                result = validCount < (fileContent.Length / 2);
            }
            return result;
        }

        public void PrintFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                IDecryptor decryptor = _keyProvider.GetDecryptor();
                byte[] decryptedBytes = decryptor.Transform(File.ReadAllBytes(filePath));
                _printer.Print(Encoding.ASCII.GetString(decryptedBytes));
            }
        }
    }
}
