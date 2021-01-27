using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickEncryptLib.Encryption;
using QuickEncryptLib.UserResponse;

namespace QuickEncrypt
{
    public class Application : IApplication
    {
        const string WELCOME_MSG = "QuickEncrypt - Written by Peter J Kingston";

        const string REQUEST_FILE_MSG = "Enter the full filepath of the desired file to encrypt:";

        const string ENCRYPTED_MSG = "Your file is encrypted! Use QuickEncrypt -r to see it's contents!";

        //const string NOT_ENCRYPTED_MSG = "This file wasn't encrypted!";

        //const string ALREADY_ENCRYPTED_MSG = "This file is already encrypted!";

        public Application(IConsolePrinter consolePrinter, IEncryptionService encryptionService, ISwitchInfo switchInfo)
        {
            _consolePrinter = consolePrinter;
            _encryptionService = encryptionService;
            _switchInfo = switchInfo;
        }

        public void Run()
        {
            if(_switchInfo.ConsoleMode != ConsoleMode.Silent)
			{
                WelcomeMessage();
                string filePath = RequestFile();

                Action<string> transform = GetTransformMode();
                //Let's let the encryption service check encryption status internally.
                //if (File.Exists(filePath) && !_encryptionService.IsEncrypted(filePath))
                if (File.Exists(filePath))
                {
                    transform(filePath);
                    EncryptedMessage();
                }
            }
			else
			{
                RunSilent();
			}
        }

        internal void RunSilent()
        {
            Action<string> transform = GetTransformMode();

            if (File.Exists(_switchInfo.TargetFile))
            {
                transform(_switchInfo.TargetFile);
            }
        }

        private Action<string> GetTransformMode()
        {
            Action<string> transform;
            switch (_switchInfo.Mode)
            {
                case CryptoMode.Encrypt:
                    transform = (string x) => { _encryptionService.EncryptFile(x); };
                    break;

                case CryptoMode.Decrypt:
                    transform = (string x) => { _encryptionService.DecryptFile(x); };
                    break;

                case CryptoMode.Read:
                    transform = (string x) => { _encryptionService.PrintFile(x); };
                    break;

                default:
                    transform = (string x) => { };
                    break;
            }
            return transform;
        }

        void WelcomeMessage() { _consolePrinter.Print(WELCOME_MSG); }
        void EncryptedMessage() { _consolePrinter.Print(ENCRYPTED_MSG); }
        //void AlreadyEncryptedMessage () { _consolePrinter.Print(ALREADY_ENCRYPTED_MSG); }
        //void NotEncryptedMessage() { _consolePrinter.Print(NOT_ENCRYPTED_MSG); }

        string RequestFile()
        {
            _consolePrinter.Print(REQUEST_FILE_MSG);
            return Console.ReadLine();
        }

        IConsolePrinter _consolePrinter;
        IEncryptionService _encryptionService;
        ISwitchInfo _switchInfo;
        
    }
}
