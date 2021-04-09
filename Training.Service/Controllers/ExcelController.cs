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

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost]
        public async Task<IActionResult> ImportExcelFile(IFormFile file)
        {
            return Ok(await _excelService.ImportExcelFileAsync(file));
        }
    }
}
