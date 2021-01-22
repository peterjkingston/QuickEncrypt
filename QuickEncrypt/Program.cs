using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEncrypt
{
	class Program
	{
		//SYNTAX: QuickEncrypt.exe <file path> [-e || -d || -r]
		//Options:
		//  -e : encryption mode DEFAULT
		//	-d : decryption mode
		//  -r : output the decrypted contents to console only
		static void Main(string[] args)
		{
			MainContainer container = new MainContainer();
			CryptoMode cryptoMode = args.Contains("-d") ? 
										CryptoMode.Decrypt : 
										CryptoMode.Encrypt;
			cryptoMode = args.Contains("-r") ?
							CryptoMode.Read :
							cryptoMode;

			if (args.Length > 0) 
			{
				container.RunSilent(args[0], cryptoMode);
			}
			else
			{
				container.Run(cryptoMode);
			}
			Console.ReadKey(true);
		}
	}
}
