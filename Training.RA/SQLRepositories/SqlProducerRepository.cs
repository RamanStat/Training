using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Training.RA.Interfaces;

namespace Training.RA.SQLServerRepository
{
    public class SqlProducerRepository : IProducerRepository
    {
        private readonly IDbContext _context;

        public SqlProducerRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Producer entity, CancellationToken cancellationToken)
        {
            await _context.Producers.AddAsync(entity, cancellationToken);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Producer entity, CancellationToken cancellationToken)
        {
            _context.Producers.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Producer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Producers
                .Include(p => p.Autoparts)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Producer> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Producers
                .Include(p => p.Autoparts)
                .FirstAsync(p => p.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Producer entity, CancellationToken cancellationToken)
        {
            _context.Instance.Entry(entity).State = EntityState.Modified;
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }
    }
}
