using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEncrypt.Encryption;
using System;

namespace QuickEncryptLib_Test
{
	[TestClass]
	public class EncryptionService_Test
	{
		const string KEY_TEST_PATH = @".\";
		EncryptionService _encryptionService = new EncryptionService(KEY_TEST_PATH);

		[TestMethod]
		public void WritesKey_WhenNoKeyFound()
		{
			//Arrange
			

			//Act

			//Assert
			throw new Exception();
		}

		[TestMethod]
		public void IsEncrypted_False_WhenPlainText()
		{
			//Arrange


			//Act

			//Assert
			throw new Exception();
		}


		[TestMethod]
		public void IsEncrypted_False_WhenNotPlainText()
		{
			//Arrange


			//Act

			//Assert
			throw new Exception();
		}
	}
}
