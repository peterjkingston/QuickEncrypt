namespace QuickEncrypt
{
    public interface ISwitchInfo
    {
        CryptoMode Mode { get; }
        string TargetFile { get; }
		ConsoleMode ConsoleMode { get; }
	}
}