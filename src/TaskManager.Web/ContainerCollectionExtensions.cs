using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DataAccess;
using TaskManager.Tracker;

namespace TaskManager.Web
{
    internal static class ContainerExtension
    {
        public static IServiceCollection AddRegistrations(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTracker()
                .AddDataProvider(configuration.GetConnectionString("Default"));
        }
    }
}