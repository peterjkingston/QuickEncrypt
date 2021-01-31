using QuickEncryptLib.UserResponse;
using System;

namespace QuickEncryptLib.Encryption
{
	public interface IEncryptionService
	{
		void EncryptFile(string filePath);
		bool IsPlainText(string filePath);
		void DecryptFile(string filePath);
		void PrintFile(string filePath);
	}
}