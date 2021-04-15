using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Training.Data.Entities;
using Training.RA.Interfaces;

namespace Training.RA.SQLRepositories
{
    public class SqlAutopartRepository : IAutopartRepository
    {
        private readonly IDbContext _context;

        public SqlAutopartRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<Autopart> CreateAsync(Autopart entity, CancellationToken cancellationToken)
        {
            var autopart =  await _context.Autoparts.AddAsync(entity, cancellationToken);

            await _context.Instance.SaveChangesAsync(cancellationToken);

            return autopart.Entity;
        }

        public async Task DeleteAsync(Autopart entity, CancellationToken cancellationToken)
        {
            _context.Autoparts.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Instance.Database.BeginTransactionAsync();
        }

        public async Task<IEnumerable<Autopart>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Autoparts
                .Include(a => a.Producer)
                .Include(a => a.Vendors)
                .Include(a => a.Cars)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Autopart> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Autoparts
                .Include(a => a.Producer)
                .Include(a => a.Vendors)
                .Include(a => a.Cars)
                .AsNoTracking()
                .FirstAsync(a => a.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Autopart entity, CancellationToken cancellationToken)
        {
            _context.Instance.Entry(entity).State = EntityState.Modified;
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }
    }
}
