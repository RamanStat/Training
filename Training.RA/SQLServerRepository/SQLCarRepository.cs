using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLCarRepository : ICarRepository
    {
        private readonly SQLDbContext _context;

        public SQLCarRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Car entity)
        {
            await _context.Cars.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Car entity)
        {
            _context.Cars.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.Include(c => c.Autoparts).AsNoTracking().ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.Include(c => c.Autoparts).AsNoTracking().FirstAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Car entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
