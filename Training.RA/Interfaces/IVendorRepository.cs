﻿using System.Threading;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.RA.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<Vendor> GetVendorByNameAsync(string vendorName, CancellationToken cancellationToken = default);
    }
}
