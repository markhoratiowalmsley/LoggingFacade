using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingFacade.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEventBasedLogging(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging((logging) =>
            {
                logging.AddConsole();
            });
            serviceCollection.AddSingleton(typeof(IEventLoggingFacade<>), typeof(EventLoggingFacade<>));
        }
    }
}
