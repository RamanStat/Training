using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExcelDataReader;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Training.Data.Entities;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.Interfaces;
using Training.Service.EqualityComparers;
using Training.Service.Validators;
using static Training.Service.Constants.ImportFileStructure;

namespace Training.Service.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;
        private readonly IAutopartRepository _autopartRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly ICarRepository _carRepository;

        public ExcelService(IMapper mapper, IAutopartRepository autopartRepository, IVendorRepository vendorRepository, IProducerRepository producerRepository, ICarRepository carRepository)
        {
            _mapper = mapper;
            _autopartRepository = autopartRepository;
            _vendorRepository = vendorRepository;
            _producerRepository = producerRepository;
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<ExcelDTO>> ImportExcelFileAsync(IFormFile file)
        {
            var dataTable = await GetDataTableFromExcelFileAsync(file);

            var dataRows = await ValidateExcelDataTableAndGetDataRowsAsync(dataTable);
            
            var excelDTOs = _mapper.Map<ExcelDTO[]>(dataRows).Distinct(new ExcelDTOEqualityComparer()).ToArray();

            await CreateAutopartsAsync(excelDTOs);
            
            return excelDTOs;
        }
        
        private static async Task<DataTable> GetDataTableFromExcelFileAsync(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            return reader.AsDataSet().Tables[0];
        }

        private static async Task<string[][]> ValidateExcelDataTableAndGetDataRowsAsync(DataTable dataTable)
        {
            var firstRowWithColumnNames = dataTable.Rows[0].ItemArray.Select(i => i.ToString()).ToArray();

            var dataRows = dataTable.AsEnumerable().Select(r => r.ItemArray.Select(i => i.ToString()).ToArray()).Skip(1).ToArray();

            if (!ValidateExcelColumnOrderWithNamesAsync(firstRowWithColumnNames))
            {
                throw new ValidationException($"Invalid columns.\n Must be {VALID_COLUMN_ORDER_WITH_NAMES}");
            }

            await ValidateDataRowsAsync(dataRows);

            return dataRows;
        }

        private static bool ValidateExcelColumnOrderWithNamesAsync(string[] cells)
        {
            return new ExcelColumnOrderWithNamesEqualityComparer().Equals(cells);
        }

        private static async Task ValidateDataRowsAsync(string[][] dataRows)
        {
            var errors = new List<string>();

            var validator = new ExcelDataRowsValidator();

            for (var i = 0; i < dataRows.Length; i++)
            {
                var result = await validator.ValidateAsync(dataRows[i]);

                if (!result.IsValid)
                {
                    errors.Add($"Number of row is {i + 1}\n" +
                               $"{string.Join("\n", result.Errors.Select(e => e.ErrorMessage))}");
                }
            }

            if (errors.Count != 0)
            {
                var list = string.Join("\n", errors);
                throw new ValidationException(list);
            }
        }

        private async Task CreateAutopartsAsync(ExcelDTO[] excelDTOs)
        {
            var transaction = await _autopartRepository.BeginTransaction();

            try
            {
                foreach (var excelDTO in excelDTOs)
                {
                    var producer = await _producerRepository.GetProducerByNameAsync(excelDTO.ProducerName);

                    var vendor = await _vendorRepository.GetVendorByNameAsync(excelDTO.VendorName);

                    var car = await _carRepository.GetCarByModelAndIssuerYearAndEngineAsync(excelDTO.CarModel, excelDTO.CarIssueYear, excelDTO.CarEngine);

                    var autopart = _mapper.Map<Autopart>(excelDTO);

                    autopart.Producer = producer;
                    autopart.ProducerId = producer.Id;
                    autopart.Cars.Add(car);
                    autopart.Vendors.Add(vendor);

                    await _autopartRepository.CreateAsync(autopart);
                }

                throw new Exception();

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
