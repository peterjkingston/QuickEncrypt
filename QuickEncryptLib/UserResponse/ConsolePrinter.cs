using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEncrypt.UserResponse
{
	public class ConsolePrinter : IConsolePrinter
	{
		public void Print(string message)
		{
			Console.WriteLine(message);
		}
	}
}
