# QuickEncrypt ![QuickEncrypt Icon](https://github.com/peterjkingston/QuickEncrypt/raw/IconBackground-PK0007/QuickEncrypt/Resources/quickencrypt_32x32.ico) 
## Description
A console application to encrypt and decrypt your plain text files! The content of encrypted files can be viewed in the conosle without writing over the file to decrypt.

## Installation
No current installers are available. Clone and build tested with VS2019, .NET Framework 4.8.

## Usage Syntax
`~\QuickEncrypt.exe filePath [-e || -d || -r]`
|Switch Element Name|Syntactic Descriptor|Description|
|:--|:-:|:--|
|FilePath|`filePath`|The fully qualified path to the target file to encrypt or decrypt.|
|FileMode|`-e`|Encrypt. The target file is encrypted and overwritten. Default FileMode.|
|   |`-d`|Decrypt. The target file is decrypted and overwritten.|
|   |`-r`|Read-Only. The target file is read, decrypted and then printed to the console.|

## Future Features
- [ ] Basic security practices/features. Currently very bare.
- [ ] Securely store keys in a remote store (like Microsoft OneDrive)
- [ ] Wrap this function in a text editor. 
