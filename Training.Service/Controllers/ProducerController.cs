using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.SDK.DTO;
using Training.SDK.Interfaces;

namespace Training.Service.Controllers
{
    [Route("api/producers")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducers()
        {
            return Ok(await _producerService.GetProducersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducerById(int id)
        {
            return Ok(await _producerService.GetProducerAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducer([FromBody]ProducerDTO producerDTO)
        {
            return Ok(await _producerService.CreateProducerAsync(producerDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducer([FromBody]ProducerDTO producerDTO)
        {
            return Ok(await _producerService.UpdateProducerAsync(producerDTO));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducerById(int id)
        {
            return Ok(await _producerService.DeleteProducerAsync(id));
        }
    }
}
