using System;
using LoggingFacade.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace LoggingFacadeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices()
                .BuildServiceProvider();


            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>();

            serviceProvider.GetService<ITestService>()?
                .DoTheStuff();
        }

        public static IServiceCollection ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEventBasedLogging();
            serviceCollection.AddSingleton<ITestService, TestService>();
            return serviceCollection;
        }
    }
}
