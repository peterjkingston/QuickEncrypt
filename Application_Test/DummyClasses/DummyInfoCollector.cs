using QuickEncrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Test
{
    public class DummyInfoCollector : IInfoCollector
    {
        public bool StringCollected { get; private set; }
        private string _preset;

        public DummyInfoCollector(string presetString)
        {
            StringCollected = false;
            _preset = presetString;
        }

        public string CollectString()
        {
            StringCollected = true;
            return _preset;
        }
    }
}
