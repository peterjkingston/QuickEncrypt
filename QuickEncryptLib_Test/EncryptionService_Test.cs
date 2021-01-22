using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEncrypt.Encryption;
using System;
using System.IO;

namespace QuickEncryptLib_Test
{
	[TestClass]
	public class EncryptionService_Test
	{
		const string KEY_TEST_PATH = @".\";

		[TestMethod]
		public void WritesKey_WhenNoKeyFound()
		{
			//Arrange
			string folderPath = @".\TempKey";
			if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }
			EncryptionService encryptionService = new EncryptionService(folderPath);
			bool actual = false;
			bool expected = true;

			//Act
			actual = File.Exists(Path.Combine(@".\TempKey", "MyQuickEncryptKey.dat")) &&
					 File.Exists(Path.Combine(@".\TempKey", "MyQuickEncryptVector.dat"));
			foreach(string fileName in Directory.GetFiles(folderPath))
			{
				File.Delete(fileName);
			}
			Directory.Delete(folderPath);

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IsNotPlainText_False_WhenPlainText()
		{
			//Arrange
			File.WriteAllText(@".\IsNotPlainText_False_WhenPlainText", "Oooogabooga!");
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
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
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
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
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
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
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
			encryptionService.EncryptFile(@".\DecryptFile_ReadsEncryptedPlainText");
			bool expected = true;

			//Act
			encryptionService.DecryptFile(@".\DecryptFile_ReadsEncryptedPlainText");
			bool actual = testContent == File.ReadAllText(@".\DecryptFile_ReadsEncryptedPlainText");

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
