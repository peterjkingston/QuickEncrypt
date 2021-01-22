using QuickEncrypt.UserResponse;
using System;

namespace QuickEncrypt.Encryption
{
	public interface IEncryptionService
	{
		void EncryptFile(string filePath);
		bool IsNotPlainText(string filePath);
		void DecryptFile(string filePath);
		Action<string> PrintFile(string filePath, IConsolePrinter consolePrinter);
	}
}