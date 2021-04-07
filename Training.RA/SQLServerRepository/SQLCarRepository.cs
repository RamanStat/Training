using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLCarRepository : SQLRepository<Car>, ICarRepository
    {
        public SQLCarRepository(SQLDbContext context) : base(context)
        {

        }
    }
}
