using Microsoft.Extensions.DependencyInjection;
using Training.SDK.Interfaces;
using Training.SDK.Services;
namespace Training.Service.Extensions
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IExcelService, ExcelService>();

            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}
