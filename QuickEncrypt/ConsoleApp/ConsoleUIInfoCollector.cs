using System;

namespace QuickEncrypt
{
    internal class ConsoleUIInfoCollector : IInfoCollector
    {
        public ConsoleUIInfoCollector()
        {
        }

        public string CollectString()
        {
            return Console.ReadLine();
        }
    }
}