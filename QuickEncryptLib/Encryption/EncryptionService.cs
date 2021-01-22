using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickEncrypt.UserResponse;

namespace QuickEncrypt.Encryption
{
	public class EncryptionService : IEncryptionService
	{
		AesManaged _cryptoProvider = new AesManaged();
		static string _quickEncryptFolder = Path.Combine(new string[]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				"QuickEncrypt"
			}
		);

		static string _keyFilePath = Path.Combine(new string[]
			{
				_quickEncryptFolder,
				"MyQuickEncryptKey.dat"
			}
		);

		static string _IVFilePath = Path.Combine(new string[]
			{
				_quickEncryptFolder,
				"MyQuickEncryptVector.dat"
			}
		);

		public EncryptionService()
		{
			//Create a key if necessary
			if (!File.Exists(_keyFilePath))
			{
				PublishKey(); 
			}

			//Load the key
			LoadKey();
		}

		private void LoadKey()
		{
			_cryptoProvider.Key = File.ReadAllBytes(_keyFilePath);
			_cryptoProvider.IV = File.ReadAllBytes(_IVFilePath);
		}

		private void PublishKey()
		{
			_cryptoProvider.GenerateKey();
			_cryptoProvider.GenerateIV();

			if (!Directory.Exists(_quickEncryptFolder))
			{
				Directory.CreateDirectory(_quickEncryptFolder);
			}

			File.WriteAllBytes(_keyFilePath, _cryptoProvider.Key);
			File.WriteAllBytes(_IVFilePath, _cryptoProvider.IV);
		}

		public void EncryptFile(string filePath)
		{
			if (!IsEncrypted(filePath))
			{
				ICryptoTransform encryptor = _cryptoProvider.CreateEncryptor();
				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(cs))
						{
							swEncrypt.Write(File.ReadAllText(filePath));
						}
						File.WriteAllBytes(filePath, ms.ToArray());
					}
				}
			}
		}

		public bool IsEncrypted(string filePath)
		{
			//Returns true if at least half the characters in the file are a letter or a number.
			string fileContent = File.ReadAllText(filePath);
			long validCount = 0;
			foreach (char character in fileContent)
			{
				if(
					char.IsWhiteSpace(character) ||
					char.IsLetterOrDigit(character) 
				)
				{
					validCount++;
				}
			}

			return validCount > fileContent.Length / 2;
		}

		public void DecryptFile(string filePath)
		{
			throw new NotImplementedException();
		}

		public Action<string> PrintFile(string filePath, IConsolePrinter consolePrinter)
		{
			throw new NotImplementedException();
		}
	}
}
