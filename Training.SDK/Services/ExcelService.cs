using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Training.SDK.DTO;
using Training.SDK.Interfaces;

namespace Training.SDK.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;

        public ExcelService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var excelDTOs = new List<ExcelDTO>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await using var stream = System.IO.File.Create(file.FileName);
            await file.CopyToAsync(stream, cancellationToken);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            reader.Read();

            while (reader.Read())
            {
                excelDTOs.Add(_mapper.Map<ExcelDTO>(reader));
            }

            return excelDTOs;
        }
    }
}
