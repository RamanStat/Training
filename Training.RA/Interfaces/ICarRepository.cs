using System.Threading;
using System.Threading.Tasks;
using Training.Data.Entities;

namespace Training.RA.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetCarByModelAndIssuerYearAndEngineAsync(string carModel, int carIssuerYear, string carEngine, CancellationToken cancellationToken = default);
    }
}
