using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickEncrypt
{
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
            TargetFile = args[0];
        }

        public string TargetFile { get; }
        public CryptoMode Mode { get; }
    }
}
