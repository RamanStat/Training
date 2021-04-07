using Data.Entities;
using MongoDB.Driver;

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

        public IMongoCollection<Order> Orders
        {
            get => _context.GetCollection<Order>("Order");
        }

        public IMongoCollection<Client> Clients
        {
            get => _context.GetCollection<Client>("Client");
        }

        public IMongoCollection<Vendor> Vendors
        {
            get => _context.GetCollection<Vendor>("Vendor");
        }

        public IMongoCollection<Producer> Producers
        {
            get => _context.GetCollection<Producer>("Producer");
        }

        public IMongoCollection<Autopart> Autoparts
        {
            get => _context.GetCollection<Autopart>("Autopart");
        }

        public IMongoCollection<Car> Cars
        {
            get => _context.GetCollection<Car>("Car");
        }
    }
}
