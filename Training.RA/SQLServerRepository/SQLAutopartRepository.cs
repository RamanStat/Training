using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLAutopartRepository : IAutopartRepository
    {
        private readonly SQLDbContext _context;

        public SQLAutopartRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Autopart entity)
        {
            await _context.Autoparts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Autopart entity)
        {
            _context.Autoparts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Autopart>> GetAllAsync()
        {
            return await _context.Autoparts.Include(a => a.Producer).Include(a => a.Vendors).Include(a => a.Cars).AsNoTracking().ToListAsync();
        }

        public async Task<Autopart> GetByIdAsync(int id)
        {
            return await _context.Autoparts.Include(a => a.Producer).Include(a => a.Vendors).Include(a => a.Cars).AsNoTracking().FirstAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Autopart entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
