using AutoMapper;
using AutoMapper.Configuration;

namespace Training.Service.Mapping
{
    public static class MapperConfigurationProvider
    {
        public static MapperConfiguration Get()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfile<ProducerProfile>();
            cfg.AddProfile<ExcelProfile>();

            var config = new MapperConfiguration(cfg);
            config.AssertConfigurationIsValid();

            return config;
        }
    }
}
