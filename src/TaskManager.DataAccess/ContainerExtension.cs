using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.DataAccess.Contracts;

namespace TaskManager.DataAccess
{
    public static class ContainerExtension
    {
        public static IServiceCollection AddDataProvider(this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString))
                .AddScoped<ITaskRecordRepository, TaskRecordRepository>();
        }
    }
}