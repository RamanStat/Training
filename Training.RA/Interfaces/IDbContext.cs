using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Training.RA.Interfaces
{
    public interface IDbContext
    {
        DbContext Instance { get; }

        DbSet<Order> Orders { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<Vendor> Vendors { get; set; }

        DbSet<Producer> Producers { get; set; }

        DbSet<Autopart> Autoparts { get; set; }

        DbSet<Car> Cars { get; set; }
    }
}
