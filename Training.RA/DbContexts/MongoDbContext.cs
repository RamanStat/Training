using MongoDB.Driver;
using Training.Data.Entities;

namespace Training.RA.DbContexts
{
    public class MongoDbContext
    {
        private IMongoDatabase _context;

        public MongoDbContext(string database)
        {
            var client = new MongoClient();
            _context = client.GetDatabase(database);
        }

        public IMongoCollection<Order> Orders => _context.GetCollection<Order>("Order");

        public IMongoCollection<Client> Clients => _context.GetCollection<Client>("Client");

        public IMongoCollection<Vendor> Vendors => _context.GetCollection<Vendor>("Vendor");

        public IMongoCollection<Producer> Producers => _context.GetCollection<Producer>("Producer");

        public IMongoCollection<Autopart> Autoparts => _context.GetCollection<Autopart>("Autopart");

        public IMongoCollection<Car> Cars => _context.GetCollection<Car>("Car");
    }
}
