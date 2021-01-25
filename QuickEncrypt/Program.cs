using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

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
			var programContainer = Containerization.BuildContainer(args);
			programContainer.Resolve<Application>();

		}
    }
}
