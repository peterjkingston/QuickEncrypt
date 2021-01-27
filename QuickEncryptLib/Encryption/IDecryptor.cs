namespace QuickEncryptLib.Encryption
{
    internal interface IDecryptor
    {
        byte[] Transform(byte[] byteData);
    }
}