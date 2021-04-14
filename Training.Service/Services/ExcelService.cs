using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExcelDataReader;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Training.SDK.DTO;
using Training.SDK.Interfaces;
using Training.Service.EqualityComparers;
using Training.Service.Validators;

namespace Training.Service.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ExcelService> _exceLogger;

        public ExcelService(IMapper mapper, ILogger<ExcelService> exceLogger)
        {
            _mapper = mapper;
            _exceLogger = exceLogger;
        }

        public async Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var dataTable = reader.AsDataSet().Tables[0];
            var firstColumnNames = dataTable.Rows[0].ItemArray.Select(i => i.ToString()).ToArray();
            var dataRows = dataTable.AsEnumerable().Select(r => r.ItemArray.Select(i => i.ToString()).ToArray()).Skip(1).ToArray();

            if (!ColumnValidation(firstColumnNames))
            {
                throw new ValidationException("Invalid column names");
            }

            var excelDTOs = _mapper.Map<ExcelDTO[]>(dataRows);

            await DataValidation(excelDTOs);
            
            return excelDTOs;
        }

        private bool ColumnValidation(string[] cells)
        {
            return new ExcelColumnNamesEqualityComparer().Equals(cells);
        }

        private async Task DataValidation(ExcelDTO[] excelDTOs)
        {
            var validator = new ExcelDTOValidator();

            foreach (var excelDTO in excelDTOs)
            {
                var result = await validator.ValidateAsync(excelDTO);

                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
        }
    }
}
