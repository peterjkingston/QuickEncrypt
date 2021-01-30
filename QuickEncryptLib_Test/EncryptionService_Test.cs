using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEncryptLib.Encryption;
using QuickEncryptLib.UserResponse;
using System;
using System.IO;

namespace QuickEncryptLib_Test
{
	[TestClass]
	public class EncryptionService_Test
	{
		const string KEY_TEST_PATH = @".\";
		IKeyInfo _tempKeyInfo = new KeyInfo(@".\TempKey");
		IKeyInfo _keyInfo = new KeyInfo(KEY_TEST_PATH);
		IOutputPrinter _consolePrinter = new ConsolePrinter();

		[TestMethod]
		public void WritesKey_WhenNoKeyFound()
		{
			//Arrange
			if (!Directory.Exists(_tempKeyInfo.FolderPath)) { Directory.CreateDirectory(_tempKeyInfo.FolderPath); }
			EncryptionService encryptionService = new EncryptionService(_tempKeyInfo, _consolePrinter);
			bool actual = false;
			bool expected = true;

			//Act
			actual = File.Exists(Path.Combine(@".\TempKey", "MyQuickEncryptKey.dat")) &&
					 File.Exists(Path.Combine(@".\TempKey", "MyQuickEncryptVector.dat"));
			foreach(string fileName in Directory.GetFiles(_tempKeyInfo.FolderPath))
			{
				File.Delete(fileName);
			}
			Directory.Delete(_tempKeyInfo.FolderPath);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IsNotPlainText_False_WhenPlainText()
		{
			//Arrange
			File.WriteAllText(@".\IsNotPlainText_False_WhenPlainText", "Oooogabooga!");
			EncryptionService encryptionService = new EncryptionService(_keyInfo, _consolePrinter);
			bool expected = false;

			//Act
			bool actual = encryptionService.IsNotPlainText(@".\IsNotPlainText_False_WhenPlainText");

			//Assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void IsNotPlainText_True_WhenExplicitlyEncrypted()
		{
			//Arrange
			File.WriteAllText(@".\IsNotPlainText_True_WhenExplicitlyEncrypted", "Oooogabooga!");
			EncryptionService encryptionService = new EncryptionService(_keyInfo, _consolePrinter);
			encryptionService.EncryptFile(@".\IsNotPlainText_True_WhenExplicitlyEncrypted");
			bool expected = true;

			//Act
			bool actual = encryptionService.IsNotPlainText(@".\IsNotPlainText_True_WhenExplicitlyEncrypted");

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Encrypt_PlainText()
		{
			//Arrange
			string testContent = "Oooogabooga!";
			File.WriteAllText(@".\Encrypt_PlainText", testContent);
			EncryptionService encryptionService = new EncryptionService(_keyInfo, _consolePrinter);
			encryptionService.EncryptFile(@".\Encrypt_PlainText");
			bool expected = false;

			//Act
			bool actual = File.ReadAllText(@".\Encrypt_PlainText") == testContent;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DecryptFile_ReadsEncryptedPlainText()
		{
			//Arrange
			string testContent = "Oooogabooga!";
			File.WriteAllText(@".\DecryptFile_ReadsEncryptedPlainText", testContent);
			EncryptionService encryptionService = new EncryptionService(_keyInfo, _consolePrinter);
			encryptionService.EncryptFile(@".\DecryptFile_ReadsEncryptedPlainText");
			bool expected = true;

			//Act
			encryptionService.DecryptFile(@".\DecryptFile_ReadsEncryptedPlainText");
			bool actual = testContent == File.ReadAllText(@".\DecryptFile_ReadsEncryptedPlainText");

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void EncryptFile_DoesntStack()
		{
			//Arrange
			string testContent = "Oooogabooga!";
			File.WriteAllText(@".\EncryptFile_DoesntStack", testContent);
			EncryptionService encryptionService = new EncryptionService(_keyInfo, _consolePrinter);
			encryptionService.EncryptFile(@".\EncryptFile_DoesntStack");
			encryptionService.EncryptFile(@".\EncryptFile_DoesntStack");
			bool expected = true;

			//Act
			encryptionService.DecryptFile(@".\EncryptFile_DoesntStack");
			bool actual = testContent == File.ReadAllText(@".\EncryptFile_DoesntStack");

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PrintFile_PrintsToOutputBuffer_Encrypted()
        {
			//Arrange
			string filePath = @".\AlwaysEncrypted";
			string testContent = "Oooogabooga!";
			OutputContainer outputContainer = new OutputContainer();
			EncryptionService encryptionService = new EncryptionService(_keyInfo, outputContainer);
			if (!File.Exists(filePath))
            {
				File.WriteAllText(filePath, testContent);
				encryptionService.EncryptFile(filePath);
			}
			bool expected = true;

			//Act
			encryptionService.PrintFile(filePath);
			bool actual = outputContainer.StoredMessage == testContent;

			//Assert
			Assert.AreEqual(expected, actual);
        }

		[TestMethod]
		public void PrintFile_PrintsToOutputBuffer_Decrypted()
		{
			//Arrange
			string filePath = @".\AlwaysDecrypted";
			string testContent = "Oooogabooga!";
			OutputContainer outputContainer = new OutputContainer();
			EncryptionService encryptionService = new EncryptionService(_keyInfo, outputContainer);
			if (!File.Exists(filePath))
			{
				File.WriteAllText(filePath, testContent);
			}
			bool expected = true;

			//Act
			encryptionService.PrintFile(filePath);
			bool actual = outputContainer.StoredMessage == testContent;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
