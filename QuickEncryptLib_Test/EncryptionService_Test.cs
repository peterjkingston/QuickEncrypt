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
			File.WriteAllText(@".\TestFile", "Oooogabooga!");
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
			bool expected = false;

			//Act
			bool actual = encryptionService.IsNotPlainText(@".\TestFile");

			//Assert
			Assert.AreEqual(expected, actual);
		}


		[TestMethod]
		public void IsNotPlainText_True_WhenExplicitlyEncrypted()
		{
			//Arrange
			File.WriteAllText(@".\TestFile2", "Oooogabooga!");
			EncryptionService encryptionService = new EncryptionService(KEY_TEST_PATH);
			encryptionService.EncryptFile(@".\TestFile2");
			bool expected = true;

			//Act
			bool actual = encryptionService.IsNotPlainText(@".\TestFile2");

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}
}
