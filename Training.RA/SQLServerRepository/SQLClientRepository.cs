using Data.Entities;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLClientRepository : SQLRepository<Client>, IClientRepository
    {
        public SQLClientRepository(SQLDbContext context) : base(context)
        {

        }
    }
}
