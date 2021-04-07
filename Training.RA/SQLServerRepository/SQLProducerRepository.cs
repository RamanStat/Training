using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLProducerRepository : IProducerRepository
    {
        private readonly SQLDbContext _context;

        public SQLProducerRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Producer entity)
        {
            await _context.Producers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Producer entity)
        {
            _context.Producers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            return await _context.Producers.Include(p => p.Autoparts).AsNoTracking().ToListAsync();
        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers.Include(p => p.Autoparts).FirstAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Producer entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
