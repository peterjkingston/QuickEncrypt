using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEncrypt
{
    //SYNTAX: QuickEncrypt.exe <target file path> [-e || -d || -r]
    //Options:
    //  -e : encryption mode DEFAULT
    //	-d : decryption mode
    //  -r : output the decrypted contents to console only
    public class SwitchInfo : ISwitchInfo
    {
        public SwitchInfo(string[] args)
        {
            CryptoMode Mode = args.Contains("-d") ?
                            CryptoMode.Decrypt :
                            CryptoMode.Encrypt;
            Mode = args.Contains("-r") ?
                            CryptoMode.Read :
                            Mode;
            if (args.Length > 0)
			{
                TargetFile = args[0];
                ConsoleMode = ConsoleMode.Silent;
            }
			else
			{
                ConsoleMode = ConsoleMode.ShowConsole;
			}
            
        }

        public string TargetFile { get; }
        public CryptoMode Mode { get; }

		public ConsoleMode ConsoleMode { get; }
	}
}
