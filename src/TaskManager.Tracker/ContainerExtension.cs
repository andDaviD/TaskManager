using Microsoft.Extensions.DependencyInjection;
using TaskManager.Tracker.Contracts;

namespace TaskManager.Tracker;

public static class ContainerExtension
{
    public static IServiceCollection AddTracker(this IServiceCollection services) =>
        services
            .AddScoped<ITaskService, TaskService>()
            .AddScoped<ITaskValidationService, TaskValidationService>()
            .AddSingleton<IDateTimeProvider, DateTimeProvider>();
}
