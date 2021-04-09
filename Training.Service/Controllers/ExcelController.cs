using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.RA.Interfaces;
using Training.SDK.Interfaces;

namespace Training.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _excelService;
        private readonly ICarRepository _carRepository;

        public ExcelController(IExcelService excelService, ICarRepository carRepository)
        {
            _excelService = excelService;
            _carRepository = carRepository;
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcelFile(IFormFile file)
        {
            return Ok(await _excelService.ImportExcelFileAsync(file));
        }
    }
}
