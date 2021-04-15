using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.Data.Entities;
using Training.RA.Interfaces;

namespace Training.RA.SQLRepositories
{
    public class SqlVendorRepository : IVendorRepository
    {
        private readonly IDbContext _context;

        public SqlVendorRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<Vendor> CreateAsync(Vendor entity, CancellationToken cancellationToken)
        {
            var vendor = await _context.Vendors.AddAsync(entity, cancellationToken);

            await _context.Instance.SaveChangesAsync(cancellationToken);

            return vendor.Entity;
        }

        public async Task DeleteAsync(Vendor entity, CancellationToken cancellationToken)
        {
            _context.Vendors.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<Vendor> GetVendorByNameAsync(string vendorName, CancellationToken cancellationToken)
        {
            var vendor = await _context.Vendors.FirstOrDefaultAsync(p => p.Name == vendorName, cancellationToken);

            if (vendor == null)
            {
                throw new ValidationException($"Vendor with name: {vendorName} does not exists");
            }

            return vendor;
        }

        public async Task<IEnumerable<Vendor>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Vendors
                .Include(v => v.Autoparts)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Vendor> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Vendors
                .Include(v => v.Autoparts)
                .AsNoTracking()
                .FirstAsync(v => v.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Vendor entity, CancellationToken cancellationToken)
        {
            _context.Instance.Entry(entity).State = EntityState.Modified;

            await _context.Instance.SaveChangesAsync(cancellationToken);
        }
    }
}
