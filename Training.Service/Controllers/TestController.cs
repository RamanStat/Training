using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.RA.Interfaces;
using Training.SDK.DTO;

namespace Training.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IAutopartRepository _autopartRepository;

        public TestController(IAutopartRepository autopartRepository)
        {
            _autopartRepository = autopartRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutopartAsync()
        {
            return Ok(await _autopartRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> GetExcel(IFormFile file)
        {
            var excelDTOs = new List<ExcelDTO>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Create(file.FileName))
            {
                await file.CopyToAsync(stream);
                using var reader = ExcelReaderFactory.CreateReader(stream);
                reader.Read();

                while (reader.Read())
                {
                    excelDTOs.Add(new ExcelDTO()
                    {
                        AutopartName = reader.GetValue(0).ToString(),
                        AutopartPrice = int.Parse(reader.GetValue(1).ToString()),
                        AutopartDescription = reader.GetValue(2).ToString(),
                        ProducerName = reader.GetValue(3).ToString(),
                        CarModel = reader.GetValue(4).ToString(),
                        CarIssueYear = int.Parse(reader.GetValue(5).ToString()),
                        CarEngine = int.Parse(reader.GetValue(6).ToString()),
                        VendorName = reader.GetValue(7).ToString(),
                    });
                }
            }

            return Ok(excelDTOs);
        }
    }
}
