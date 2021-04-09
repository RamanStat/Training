using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly IDbContext _context;

        public SqlCarRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Car entity, CancellationToken cancellationToken)
        {
            await _context.Cars.AddAsync(entity, cancellationToken);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Car entity, CancellationToken cancellationToken)
        {
            _context.Cars.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Car>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Cars
                .Include(c => c.Autoparts)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Car> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Cars
                .Include(c => c.Autoparts)
                .AsNoTracking()
                .FirstAsync(c => c.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Car entity, CancellationToken cancellationToken)
        {
            _context.Instance.Entry(entity).State = EntityState.Modified;
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }
    }
}
