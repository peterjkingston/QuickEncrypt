using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickEncryptLib.UserResponse;
using QuickEncryptLib.Encryption;

namespace QuickEncryptLib.Encryption
{
	public class EncryptionService : IEncryptionService
	{
		AesManaged _cryptoProvider = new AesManaged();
		IKeyInfo _keyinfo;
		IOutputPrinter _consolePrinter;

		public EncryptionService(IKeyInfo keyInfo, IOutputPrinter consolePrinter)
		{
			_consolePrinter = consolePrinter;
			_keyinfo = keyInfo;

			//Create a key if necessary
			if (!File.Exists(_keyinfo.KeyPath))
			{
				PublishKey();
			}

			//Load the key
			LoadKey();
		}

		private void LoadKey()
		{
			_cryptoProvider.Key = File.ReadAllBytes(_keyinfo.KeyPath);
			_cryptoProvider.IV = File.ReadAllBytes(_keyinfo.VectorPath);
		}

		private void PublishKey()
		{
			_cryptoProvider.GenerateKey();
			_cryptoProvider.GenerateIV();

			if (!Directory.Exists(_keyinfo.FolderPath))
			{
				Directory.CreateDirectory(_keyinfo.FolderPath);
			}

			File.WriteAllBytes(_keyinfo.KeyPath, _cryptoProvider.Key);
			File.WriteAllBytes(_keyinfo.VectorPath, _cryptoProvider.IV);
		}

		public void EncryptFile(string filePath)
		{
			if (IsPlainText(filePath))
			{
				ICryptoTransform encryptor = _cryptoProvider.CreateEncryptor(_cryptoProvider.Key, _cryptoProvider.IV);
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

		public bool IsPlainText(string filePath)
		{
			//Returns true if at least a fifth the characters in the file are a letter or a number.
			string fileContent = File.ReadAllText(filePath);
			long validCount = 0;
			foreach (char character in fileContent)
			{
				if(
					char.IsWhiteSpace(character) ||
					char.IsLetter(character) 
				)
				{
					validCount++;
				}
			}

			//Quick fix, on from IsNotPlainText, changed to IsPlainText
			//Added ! to result to flip
			//PK 1/31/2021
			return !(validCount < (fileContent.Length / 2));
		}

		public void DecryptFile(string filePath)
		{
			if (!IsPlainText(filePath))
			{
				byte[] decrypted = Decrypt(File.ReadAllBytes(filePath));
				File.WriteAllBytes(filePath, decrypted);
			}
		}

		private byte[] Decrypt(byte[] buffer)
		{
			byte[] decrypted;
			ICryptoTransform decryptor = _cryptoProvider.CreateDecryptor(_cryptoProvider.Key, _cryptoProvider.IV);
			using (MemoryStream ms = new MemoryStream(buffer))
			{
				using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
				{
					using (StreamReader swDecrypt = new StreamReader(cs))
					{
						decrypted = Encoding.ASCII.GetBytes(swDecrypt.ReadToEnd());
					}
				}
			}
			return decrypted;
		}

		public void PrintFile(string filePath)
		{
            if (!IsPlainText(filePath))
            {
				byte[] decrypted = Decrypt(File.ReadAllBytes(filePath));
				_consolePrinter.Print(Encoding.ASCII.GetString(decrypted));
			}
            else
            {
				_consolePrinter.Print(File.ReadAllText(filePath));
            }
		}
	}
}
