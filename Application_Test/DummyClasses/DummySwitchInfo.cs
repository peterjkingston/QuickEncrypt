using QuickEncrypt;

namespace Application_Test
{
    internal class DummySwitchInfo : ISwitchInfo
    {
        public DummySwitchInfo(CryptoMode cryptoMode, string targetFile, ConsoleMode consoleMode)
        {
            Mode = cryptoMode;
            TargetFile = targetFile;
            ConsoleMode = consoleMode;
        }

        public CryptoMode Mode { get; private set; }

        public string TargetFile { get; private set; }

        public ConsoleMode ConsoleMode { get; private set; }
    }
}