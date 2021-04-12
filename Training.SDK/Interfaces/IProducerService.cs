using System.Collections.Generic;
using System.Threading.Tasks;
using Training.SDK.DTO;

namespace Training.SDK.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerDTO>> GetProducersAsync();

        Task<ProducerDTO> CreateProducerAsync(ProducerDTO producerDTO);

        Task<ProducerDTO> GetProducerAsync(int id);

        Task<ProducerDTO> UpdateProducerAsync(ProducerDTO producerDTO);

        Task<ProducerDTO> DeleteProducerAsync(int id);
    }
}
