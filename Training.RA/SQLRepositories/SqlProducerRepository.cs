﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Training.Data.Entities;
using Training.RA.Interfaces;

namespace Training.RA.SqlRepositories
{
    public class SqlProducerRepository : IProducerRepository
    {
        private readonly IDbContext _context;

        public SqlProducerRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<Producer> CreateAsync(Producer entity, CancellationToken cancellationToken)
        {
            var producer = await _context.Producers.AddAsync(entity, cancellationToken);

            await _context.Instance.SaveChangesAsync(cancellationToken);

            return producer.Entity;
        }

        public async Task DeleteAsync(Producer entity, CancellationToken cancellationToken)
        {
            _context.Producers.Remove(entity);
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }

        public async Task<Producer> GetProducerByNameAsync(string producerName, CancellationToken cancellationToken)
        { 
            var producer = await _context.Producers
                .FirstOrDefaultAsync(p => p.Name == producerName, cancellationToken);

            if (producer == null)
            {
                throw new ValidationException($"Producer with name: {producerName} does not exists");
            }

            return producer;
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
                .ThenInclude(a => a.Cars)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(Producer entity, CancellationToken cancellationToken)
        {
            var x = _context.Instance.Entry(entity).State = EntityState.Modified;
            await _context.Instance.SaveChangesAsync(cancellationToken);
        }
    }
}
