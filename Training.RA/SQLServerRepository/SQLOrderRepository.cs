using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Training.RA.DbContexts;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly SQLDbContext _context;

        public SQLOrderRepository(SQLDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.Client).Include(o => o.Car).Include(o => o.Autopart).AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(o => o.Client).Include(o => o.Car).Include(o => o.Autopart).AsNoTracking().FirstAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
