namespace QuickEncryptLib.Encryption
{
    public interface IEncryptor
    {
        byte[] Transform(byte[] byteData);
    }
}