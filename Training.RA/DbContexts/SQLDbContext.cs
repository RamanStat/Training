using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Training.RA.Extensions;
using Training.RA.Interfaces;

namespace Training.RA.DbContexts
{
    public class SqlDbContext : DbContext, IDbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        public DbContext Instance => this;

        public DbSet<Order> Orders { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Autopart> Autoparts { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
