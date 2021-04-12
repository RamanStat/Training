using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Training.Data.Entities;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.Interfaces;

namespace Training.Service.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IMapper _mapper;
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IMapper mapper, IProducerRepository producerRepository)
        {
            _mapper = mapper;
            _producerRepository = producerRepository;
        }

        public async Task<ProducerDTO> GetProducerAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);
            
            return _mapper.Map<ProducerDTO>(producer);
        }

        public async Task<IEnumerable<ProducerDTO>> GetProducersAsync()
        {
            var producers = await _producerRepository.GetAllAsync();

            return _mapper.Map<ProducerDTO[]>(producers);
        }

        public async Task<ProducerDTO> CreateProducerAsync(ProducerDTO producerDTO)
        {
            var producer = _mapper.Map<Producer>(producerDTO);

            producer = await _producerRepository.CreateAsync(producer);

            return _mapper.Map<ProducerDTO>(producer);
        }

        public async Task<ProducerDTO> UpdateProducerAsync(ProducerDTO producerDTO)
        {
            var producer = _mapper.Map<Producer>(producerDTO);

            await _producerRepository.UpdateAsync(producer);

            return producerDTO;
        }

        public async Task<ProducerDTO> DeleteProducerAsync(int id)
        {
            var producer = await _producerRepository.GetByIdAsync(id);

            await _producerRepository.DeleteAsync(producer);

            return _mapper.Map<ProducerDTO>(producer);
        }
    }
}
