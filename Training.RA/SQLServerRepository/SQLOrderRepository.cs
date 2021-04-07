using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLOrderRepository : SQLRepository<Order>, IOrderRepository
    {
        public SQLOrderRepository(SQLDbContext context) : base(context)
        {

        }
    }
}
