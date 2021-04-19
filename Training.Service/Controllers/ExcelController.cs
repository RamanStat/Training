using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Training.SDK.DTO;
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

        [HttpGet("producer")]
        public async Task<IActionResult> SingleExportAutoparts(int id, string carModel)
        {
            return File(await _excelService.SingleExportAutopartsAsync(id, carModel), CONTENT_TYPE, FILE_NAME);
        }

        [HttpPost("producers")]
        public async Task<IActionResult> BulkExportAutoparts([FromBody]BulkDTO bulkDTO)
        {
            return File(await _excelService.BulkExportAutopartsAsync(bulkDTO), CONTENT_TYPE, FILE_NAME);
        }
    }
}
