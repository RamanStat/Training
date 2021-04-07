using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLVendorRepository : IVendorRepository
    {
        private readonly SQLDbContext _context;

        public SQLVendorRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Vendor entity)
        {
            await _context.Vendors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vendor entity)
        {
            _context.Vendors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync()
        {
            return await _context.Vendors.Include(v => v.Autoparts).AsNoTracking().ToListAsync();
        }

        public async Task<Vendor> GetByIdAsync(int id)
        {
            return await _context.Vendors.Include(v => v.Autoparts).AsNoTracking().FirstAsync(v => v.Id == id);
        }

        public async Task UpdateAsync(Vendor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
