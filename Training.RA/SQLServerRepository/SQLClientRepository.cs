using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLClientRepository : IClientRepository
    {
        private readonly SQLDbContext _context;

        public SQLClientRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client entity)
        {
            _context.Clients.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(c => c.Orders).AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _context.Clients.Include(c => c.Orders).FirstAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
