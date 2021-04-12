using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Training.Service.Mapping;

namespace Training.Service.Extensions
{
    public static class MapperConfigurationExpression
    {
        private static readonly Action<IMapperConfigurationExpression> ConfigAction = m => m.AddProfile(new MappingProfile()); 

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(ConfigAction, typeof(Startup));
        }

        public static IMapper CreateAutoMapper()
        {
            return new MapperConfiguration(ConfigAction).CreateMapper();
        }
    }
}
