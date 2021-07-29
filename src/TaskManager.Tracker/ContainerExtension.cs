using Microsoft.Extensions.DependencyInjection;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker
{
    public static class ContainerExtension
    {
        public static IServiceCollection AddTracker(this IServiceCollection services)
        {
            return services
                .AddScoped<ITaskService, TaskService>()
                .AddScoped<ITaskValidationService, TaskValidationService>()
                .AddSingleton<IDateTimeProvider, DateTimeProvider>();
        }
    }
}