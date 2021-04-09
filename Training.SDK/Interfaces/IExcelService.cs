using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Training.SDK.DTO;

namespace Training.SDK.Interfaces
{
    public interface IExcelService
    {
        Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file, CancellationToken cancellationToken = default);
    }
}
