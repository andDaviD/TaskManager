using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DataAccess;
using TaskManager.Tracker;

namespace TaskManager.Web;

internal static class ContainerCollectionExtensions
{
    public static IServiceCollection AddRegistrations(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddTracker()
            .AddDataProvider(configuration.GetConnectionString("Default"));
}
