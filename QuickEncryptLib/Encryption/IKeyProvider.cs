namespace QuickEncryptLib.Encryption
{
    public interface IKeyProvider
    {
        IDecryptor GetDecryptor();
        IEncryptor GetEncryptor();
    }
}