using QuickEncryptLib.UserResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEncryptLib_Test
{
    public class OutputContainer : IOutputPrinter
    {
        public string StoredMessage { get; private set; }

        public void Print(string message)
        {
            StoredMessage = message;
        }
    }
}
