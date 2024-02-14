using CoreWCF.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace CoreWCFConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ServiceProvider sp = CreateProvider();
            IConfigurationHolder configHOlde = GetConfigurationHolder(sp);
        }

        protected static ServiceProvider CreateProvider()
        {
            var services = new ServiceCollection();
            services.AddServiceModelServices();
            var startDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName; // just for test... the path needs to come correctly.

            services.AddServiceModelConfigurationManagerFile(startDirectory + "/Web.Config");

            return services.BuildServiceProvider();
        }

        protected static IConfigurationHolder GetConfigurationHolder(ServiceProvider provider)
        {
            IConfigureOptions<ServiceModelOptions> options = provider.GetRequiredService<IConfigureOptions<ServiceModelOptions>>();
            options.Configure(new ServiceModelOptions());
            IConfigurationHolder settingHolder = provider.GetService<IConfigurationHolder>();
            return settingHolder;
        }
    }
}
