using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Training.RA.DbContexts;
using Training.RA.Interfaces;
using Training.RA.SQLRepositories;

namespace Training.Service.Extensions
{
    public static class RegisterRepositories
    {
        public static IServiceCollection RegisterSqlRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSSQLServer"));
            });

            services.AddScoped<IDbContext, SqlDbContext>();

            services.AddScoped<ICarRepository, SqlCarRepository>();

            services.AddScoped<IAutopartRepository, SqlAutopartRepository>();

            services.AddScoped<IProducerRepository, SqlProducerRepository>();

            services.AddScoped<IVendorRepository, SqlVendorRepository>();

            return services;
        }
    }
}
