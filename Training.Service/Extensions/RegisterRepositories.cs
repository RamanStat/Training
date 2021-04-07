using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training.RA.DbContexts;
using Training.RA.Interfaces;
using Training.RA.SQLServerRepository;

namespace Training.Service.Extensions
{
    public static class RegisterRepositories
    {
        public static void RegisterMongoRepositories(this IServiceCollection services, IConfiguration configuration)
        {

        }

        public static void RegisterSQLRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SQLDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSSQLServer"));
            });

            services.AddScoped<ICarRepository, SQLCarRepository>();

            services.AddScoped<IAutopartRepository, SQLAutopartRepository>();

            services.AddScoped<IClientRepository, SQLClientRepository>();

            services.AddScoped<IOrderRepository, SQLOrderRepository>();

            services.AddScoped<IProducerRepository, SQLProducerRepository>();

            services.AddScoped<IVendorRepository, SQLVendorRepository>();
        }
    }
}
