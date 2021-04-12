using Microsoft.Extensions.DependencyInjection;
using Training.Service.Mapping;

namespace Training.Service.Extensions
{
    public static class MapperConfigurationExpression
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(a => a.AddProfile<MappingProfile>(), typeof(Startup));
        }
    }
}
