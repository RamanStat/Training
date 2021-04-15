using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.Data.Entities;
using Training.RA.Interfaces;

namespace Training.RA.SQLRepositories
{
    public class SqlCarRepository : ICarRepository
    {
        private readonly IDbContext _context;

        public SqlCarRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateAsync(Car entity, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.AddAsync(entity, cancellationToken);

            await _context.Instance.SaveChangesAsync(cancellationToken);

            return car.Entity;
        }

        public async Task DeleteAsync(Car entity, CancellationToken cancellationToken)
        {
            _context.Cars.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<Car> GetCarByModelAndIssuerYearAndEngineAsync(string carModel, int carIssuerYear, int carEngine, CancellationToken cancellationToken)
        {
            return await _context.Cars
                .FirstOrDefaultAsync(c => c.Model == carModel
                        && c.IssueYear == carIssuerYear 
                        && c.Engine == carEngine, 
                        cancellationToken);
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
