using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLVendorRepository : SQLRepository<Vendor>, IVendorRepository
    {
        public SQLVendorRepository(SQLDbContext context) : base(context)
        {

        }
    }
}
