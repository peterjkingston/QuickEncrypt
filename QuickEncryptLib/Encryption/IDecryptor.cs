namespace QuickEncryptLib.Encryption
{
    public interface IDecryptor
    {
        byte[] Transform(byte[] byteData);
    }
}