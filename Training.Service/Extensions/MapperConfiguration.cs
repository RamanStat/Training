using Microsoft.Extensions.DependencyInjection;
using Training.Service.Mapping;

namespace Training.Service.Extensions
{
    public static class MapperConfiguration
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapper = MapperConfigurationProvider.Get().CreateMapper();

            return services.AddSingleton(mapper);
        }
    }
}
