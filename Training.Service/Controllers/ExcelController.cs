using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.SDK.Interfaces;
using static Training.Service.Constants.ExportFileSettings;

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

        [HttpGet("producer/{id}")]
        public async Task<IActionResult> ExportAutopartsByProducerId(int id)
        {
            return File(await _excelService.ExportAutopartsByProducerIdAsync(id), CONTENT_TYPE, FILE_NAME);
        }
    }
}
