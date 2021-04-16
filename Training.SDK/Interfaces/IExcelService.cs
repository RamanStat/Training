using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Training.SDK.DTO;

namespace Training.SDK.Interfaces
{
    public interface IExcelService
    {
        Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file);

        Task<byte[]> ExportAutopartsByProducerIdAsync(int producerId, string carModel);
    }
}
