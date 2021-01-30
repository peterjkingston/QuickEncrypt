using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEncrypt;
using QuickEncryptLib_Test;
using System;
using System.IO;

namespace Application_Test
{
    [TestClass]
    public class Application_Test
    {
        [TestMethod]
        public void Run_Encrypt_ShowConsole()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Encrypt,
                GetAnyFile(),
                ConsoleMode.ShowConsole
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService,switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = encryptionService.FileEncrypted;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_Decrypt_ShowConsole()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Decrypt,
                GetAnyFile(),
                ConsoleMode.ShowConsole
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService, switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = outputContainer.StoredMessage != testContent;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_Read_ShowConsole()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Read,
                GetAnyFile(),
                ConsoleMode.ShowConsole
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService, switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = outputContainer.StoredMessage != testContent;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_Encrypt_Silent()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Encrypt,
                GetAnyFile(),
                ConsoleMode.Silent
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService, switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = encryptionService.FileEncrypted;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_Decrypt_Silent()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Decrypt,
                GetAnyFile(),
                ConsoleMode.Silent
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService, switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = outputContainer.StoredMessage != testContent;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Run_Read_Silent()
        {
            //Arrange
            OutputContainer outputContainer = new OutputContainer();
            DummyInfoCollector infoCollector = new DummyInfoCollector(GetAnyFile());
            DummyEncryptionService encryptionService = new DummyEncryptionService();
            DummySwitchInfo switchInfo = new DummySwitchInfo(
                CryptoMode.Read,
                GetAnyFile(),
                ConsoleMode.Silent
                ); 
            Application app = new Application(outputContainer, infoCollector, encryptionService, switchInfo);
            bool expected = true;

            //Act
            app.Run();
            bool actual = outputContainer.StoredMessage != testContent; 

            //Assert
            Assert.AreEqual(expected, actual);
        }

        const string testContent = "Ooogabooga!";

        private string GetAnyFile()
        {
            string fileContent = testContent;
            string filepath = @".\AnyFile";
            if (!File.Exists(filepath))
            {
                File.WriteAllText(filepath, fileContent);
            }
            return filepath;
        }
    }
}
