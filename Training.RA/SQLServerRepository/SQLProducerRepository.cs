using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLProducerRepository : SQLRepository<Producer>, IProducerRepository
    {
        public SQLProducerRepository(SQLDbContext context) : base(context)
        {

        }
    }
}
