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
        private readonly IVendorRepository _vendorRepository;
        private readonly IProducerRepository _producerRepository;
        private readonly ICarRepository _carRepository;
        private readonly string _validColumnOrderWithNames = "AUTOPARTNAME-AUTOPARTPRICE-AUTOPARTDESCRIPTION-PRODUCERNAME-CARMODEL-CARISSUEYEAR-CARENGINE-VENDORNAME";

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
            var firstRowWithColumnNames = dataTable.Rows[0].ItemArray.Select(i => i.ToString()).ToArray();
            var dataRows = dataTable.AsEnumerable().Select(r => r.ItemArray.Select(i => i.ToString()).ToArray()).Skip(1).ToArray();
            
            if (!ValidateExcelColumnOrderWithNamesAsync(firstRowWithColumnNames))
            {
                throw new ValidationException($"Invalid columns.\n Must be {_validColumnOrderWithNames}");
            }

            var excelDTOs = _mapper.Map<ExcelDTO[]>(dataRows).Distinct(new ExcelDTOEqualityComparer()).ToArray();

            await ValidateExcelDTOsAsync(excelDTOs);

            await CreateAutopartsAsync(excelDTOs);
            
            return excelDTOs;
        }

        private async Task<DataTable> GetDataTableFromExcelFileAsync(IFormFile file)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            await using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            return reader.AsDataSet().Tables[0];
        }

        private bool ValidateExcelColumnOrderWithNamesAsync(string[] cells)
        {
            return new ExcelColumnOrderWithNamesEqualityComparer().Equals(cells);
        }

        private async Task ValidateExcelDTOsAsync(ExcelDTO[] excelDTOs)
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

        private async Task CreateAutopartsAsync(ExcelDTO[] excelDTOs)
        {
            foreach (var excelDTO in excelDTOs)
            {
                var producer = await _producerRepository.GetProducerAndCreateIfNotExistAsync(excelDTO.ProducerName);

                var vendor = await _vendorRepository.GetVendorAndCreateIfNotExistAsync(excelDTO.VendorName);

                var car = await _carRepository.GetCarAndCreateIfNotExistAsync(excelDTO.CarModel, excelDTO.CarIssueYear, excelDTO.CarEngine);

                var autopart = _mapper.Map<Autopart>(excelDTO);

                autopart.Producer = producer;
                autopart.ProducerId = producer.Id;
                autopart.Cars.Add(car);
                autopart.Vendors.Add(vendor);
                
                await _autopartRepository.CreateAsync(autopart);
            }
        }
    }
}
