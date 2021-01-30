using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEncrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Test
{
    [TestClass]
    public class SwitchInfo_Test
    {
        const string VALID_FILEPATH_NONEXISTENT = @".\Not a path";
        const string INVALID_FILEPATH = @".\<>|??";

        [TestMethod]
        public void CTOR_RecognizesValidFilePath()
        {
            //Arrange
            string[] args = new string[]
            {
                Application_Test.GetAnyFile()
            };
            bool expected = true;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.TargetFile == Application_Test.GetAnyFile();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CTOR_RecognizesValidFilePath_NonExistent()
        {
            //Arrange
            string[] args = new string[]
            {
                VALID_FILEPATH_NONEXISTENT
            };
            bool expected = true;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.TargetFile == VALID_FILEPATH_NONEXISTENT;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CTOR_RejectsInvalidFilePath()
        {
            //Arrange
            string[] args = new string[]
            {
                INVALID_FILEPATH
            };
            bool expected = false;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.TargetFile == INVALID_FILEPATH;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CTOR_TakesE()
        {
            //Arrange
            string[] args = new string[]
            {
                "-e"
            };
            bool expected = true;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.Mode == CryptoMode.Encrypt;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CTOR_TakesR()
        {
            //Arrange
            string[] args = new string[]
            {
                "-r"
            };
            bool expected = true;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.Mode == CryptoMode.Read;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CTOR_TakesD()
        {
            //Arrange
            string[] args = new string[]
            {
                "-d"
            };
            bool expected = true;

            //Act
            SwitchInfo switchInfo = new SwitchInfo(args);
            bool actual = switchInfo.Mode == CryptoMode.Decrypt;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
