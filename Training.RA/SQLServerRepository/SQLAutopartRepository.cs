using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLAutopartRepository : SQLRepository<Autopart>, IAutopartRepository
    {
        public SQLAutopartRepository(SQLDbContext context) : base(context)
        {

        }


    }
}
