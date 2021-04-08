using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.Interfaces;

namespace Training.SDK.Services
{
    public class ExcelService : IExcelService
    {
        public ExcelService()
        {

        }

        public async Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file)
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

            return excelDTOs;
        }
    }
}
