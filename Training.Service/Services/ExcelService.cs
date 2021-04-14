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
using Training.Data.Entities;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.Interfaces;
using Training.Service.EqualityComparers;
using Training.Service.Validators;

namespace Training.Service.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;
        private readonly IAutopartRepository _autopartRepository;

        public ExcelService(IMapper mapper, IAutopartRepository autopartRepository)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
        }

        public async Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file)
        {
            var dataTable = await GetDataTableFromExcelFile(file);
            var firstColumnNames = dataTable.Rows[0].ItemArray.Select(i => i.ToString()).ToArray();
            var dataRows = dataTable.AsEnumerable().Select(r => r.ItemArray.Select(i => i.ToString()).ToArray()).Skip(1).ToArray();
            
            if (!ValidateExcelColumnNames(firstColumnNames))
            {
                throw new ValidationException("Invalid column names");
            }

            var excelDTOs = _mapper.Map<ExcelDTO[]>(dataRows).Distinct().ToArray();

            await ValidateExcelDTOs(excelDTOs);

            var autopart = _mapper.Map<Autopart>(excelDTOs);

            await _autopartRepository.CreateAsync(autopart);
            
            return excelDTOs;
        }

        private async Task<DataTable> GetDataTableFromExcelFile(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            return reader.AsDataSet().Tables[0];
        }

        private bool ValidateExcelColumnNames(string[] cells)
        {
            return new ExcelColumnNamesEqualityComparer().Equals(cells);
        }

        private async Task ValidateExcelDTOs(ExcelDTO[] excelDTOs)
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
