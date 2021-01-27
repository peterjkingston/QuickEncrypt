namespace QuickEncryptLib.Encryption
{
    internal interface IEncryptor
    {
        byte[] Transform(byte[] byteData);
    }
}