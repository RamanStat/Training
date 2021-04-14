using System.Threading;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.RA.Interfaces
{
    public interface IProducerRepository : IRepository<Producer>
    {
        Task<Producer> GetProducerAndCreateIfNotExistAsync(string producerName, CancellationToken cancellationToken = default);
    }
}
