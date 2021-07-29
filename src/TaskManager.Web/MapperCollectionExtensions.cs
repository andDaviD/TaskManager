using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace TaskManager.Web
{
    internal static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}