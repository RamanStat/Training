using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Training.Service.Mapping;

namespace Training.Service.Extensions
{
    public static class MapperConfigurationExpression
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(a => a.AddProfile<MappingProfile>(), typeof(Startup));
        }

        public static IMapper CreateAutoMapper()
        {
            return new MapperConfiguration(mc => mc.AddProfile(new MappingProfile())).CreateMapper();
        }
    }
}
