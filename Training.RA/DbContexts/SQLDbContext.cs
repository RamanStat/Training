using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Training.RA.DbContexts
{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Autopart> Autoparts { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
