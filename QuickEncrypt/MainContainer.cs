using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickEncrypt.Encryption;
using QuickEncrypt.UserResponse;

namespace QuickEncrypt
{
	public class MainContainer
	{
		const string WELCOME_MSG = "QuickEncrypt - Written by Peter J Kingston";
								 
		const string REQUEST_FILE_MSG = "Enter the full filepath of the desired file to encrypt:";

		const string ENCRYPTED_MSG = "Your file is encrypted! Use QuickEncrypt -r to see it's contents!";

		//const string NOT_ENCRYPTED_MSG = "This file wasn't encrypted!";

		//const string ALREADY_ENCRYPTED_MSG = "This file is already encrypted!";

		internal void Run(CryptoMode cryptoMode)
		{
			WelcomeMessage();
			string filePath = RequestFile();

			Action<string> transform = GetTransformMode(cryptoMode);
			//Let's let the encryption service check encryption status internally.
			//if (File.Exists(filePath) && !_encryptionService.IsEncrypted(filePath))
			if(File.Exists(filePath))
			{
				transform(filePath);
				EncryptedMessage();
			}
		}

		internal void RunSilent(string filePath, CryptoMode cryptoMode)
		{
			Action<string> transform = GetTransformMode(cryptoMode);

			if (File.Exists(filePath) && !_encryptionService.IsNotPlainText(filePath)) 
			{ 
				transform(filePath); 
			}			
		}

		private Action<string> GetTransformMode(CryptoMode cryptoMode)
		{
			Action<string> transform;
			switch (cryptoMode)
			{
				case CryptoMode.Encrypt:
					transform = (string x) => { _encryptionService.EncryptFile(x); };
					break;

				case CryptoMode.Decrypt:
					transform = (string x) => { _encryptionService.DecryptFile(x); };
					break;

				case CryptoMode.Read:
					transform = (string x) => { _encryptionService.PrintFile(x, _consolePrinter); };
					break;

				default:
					transform = (string x) => { };
					break;
			}
			return transform;
		}

		void WelcomeMessage() { _consolePrinter.Print(WELCOME_MSG); }
		void EncryptedMessage () { _consolePrinter.Print(ENCRYPTED_MSG); }
		//void AlreadyEncryptedMessage () { _consolePrinter.Print(ALREADY_ENCRYPTED_MSG); }
		//void NotEncryptedMessage() { _consolePrinter.Print(NOT_ENCRYPTED_MSG); }

		string RequestFile() 
		{
			_consolePrinter.Print(REQUEST_FILE_MSG);
			return Console.ReadLine(); 
		}

		IConsolePrinter _consolePrinter = new ConsolePrinter();
		IEncryptionService _encryptionService = new EncryptionService();
	}
}
