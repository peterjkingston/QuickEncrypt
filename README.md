<h1 id="project-title">QuickEncrypt<img src="https://github.com/peterjkingston/QuickEncrypt/raw/master/QuickEncrypt/Resources/quickencrypt_32x32.ico" alt="QuickEncrypt Icon"/></h1>  
<h2>Description</h2>
<p>A console application to encrypt and decrypt your plain text files! The content of encrypted files can be viewed in the conosle without writing over the file to decrypt.</p>

<h2>Installation</h2>
<p>No current installers are available. Clone and build tested with VS2019, .NET Framework 4.8.</p>

<h2>Usage Syntax</h2>
<code>~\QuickEncrypt.exe filePath [-e || -d || -r]</code>
<br/>
<table>
    <tr>
        <td>Switch Element Name</td><td>Syntactic Descriptor</td><td>Description</td>
    </tr>
    <tr>
        <td>FilePath</td><td><code>filePath</code></td><td>The fully qualified path to the target file to encrypt or decrypt.</td>
    </tr>
    <tr>
        <td>FileMode</td><td><code>-e</code></td><td>Encrypt. The target file is encrypted and overwritten. Default FileMode.</td>
    </tr>
    <tr>
        <td></td><td><code>-d</code></td><td>Decrypt. The target file is decrypted and overwritten.</td>
    </tr>
    <tr>
        <td></td><td><code>-r</code></td><td>Read-Only. The target file is read, decrypted and then printed to the console.</td>
    </tr>
</table>

<h2>Future Features</h2>
- [ ] Basic security practices/features. Currently very bare.
- [ ] Securely store keys in a remote store (like Microsoft OneDrive)
- [ ] Wrap this function in a text editor. 

<h2>Disclaimer</h2>
<p>There are currently no releases of this software and it is not advised to be used for any security purpose at this time. I am not liable for any usage of this software in it's current state.</p>
