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
        public static void RegisterSqlRepositories(this IServiceCollection services, IConfiguration configuration)
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
        }
    }
}
