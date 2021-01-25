using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickEncryptLib.Encryption;
using QuickEncryptLib.UserResponse;

namespace QuickEncrypt
{
    internal static class Containerization
    {
        internal static IContainer BuildContainer(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance<KeyInfo>(new KeyInfo("")).As<IKeyInfo>();
            builder.RegisterType<EncryptionService>().As<IEncryptionService>();
            builder.RegisterType<ConsolePrinter>().As<IConsolePrinter>();

            return builder.Build();
        }
    }
}
