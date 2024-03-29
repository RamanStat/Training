﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClosedXML.Excel;
using ExcelDataReader;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Training.Data.Entities;
using Training.RA;
using Training.RA.Interfaces;
using Training.SDK.DTO;
using Training.SDK.Interfaces;
using Training.Service.EqualityComparers;
using Training.Service.ExcelValidator.ConcreteExcel;
using Training.Service.Validators;
using static Training.Service.Constants.ImportFileColumnNames;
using static Training.Service.Constants.ImportFileOffsets;

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

        public async Task<byte[]> SingleExportAutopartsAsync(int producerId, string carModel)
        {
            Expression<Func<Car, bool>> findByCarModel = car => carModel == null || car.Model == carModel;

            var autoparts = await _autopartRepository.GetByProducerIdWithPredicateAsync(producerId, findByCarModel);

            using var workbook = new XLWorkbook();

            var workSheet = CreateWorkSheetWithColumnNames(workbook);

            FillWorkSheetWithDataAndAutoSizeColumns(workSheet, autoparts);

            await using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public async Task<byte[]> BulkExportAutopartsAsync(BulkDTO bulkDTO)
        {
            using var workbook = new XLWorkbook();

            var workSheet = CreateWorkSheetWithColumnNames(workbook);
            var startRow = TABLE_ROW_OFFSET + 1;

            foreach (var producerId in bulkDTO.ProducersIds)
            {
                Expression<Func<Car, bool>> findByCarModelAndIssueYear = car =>
                    (bulkDTO.Models == null || bulkDTO.Models.Contains(car.Model))
                    && (bulkDTO.IssueYears == null || bulkDTO.IssueYears.Contains(car.IssueYear));

                var autoparts = await _autopartRepository.GetByProducerIdWithPredicateAsync(producerId, findByCarModelAndIssueYear);
                
                FillWorkSheetWithDataAndAutoSizeColumns(workSheet, autoparts, startRow);

                startRow += autoparts.Sum(a => a.Cars.Count + a.Vendors.Count);
            }
            
            await using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
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
            var firstRowWithColumnNames = dataTable.Rows[TABLE_ROW_OFFSET - 1].ItemArray.Select(i => i.ToString()).ToArray();

            var dataRows = dataTable.AsEnumerable().Select(r => r.ItemArray.Select(i => i.ToString()).ToArray()).Skip(TABLE_ROW_OFFSET).ToArray();

            await ValidateExcelColumnNamesWithOrderAsync(firstRowWithColumnNames);

            await ValidateDataRowsAsync(dataRows);

            return dataRows;
        }

        private static async Task ValidateExcelColumnNamesWithOrderAsync(string[] cells)
        {
            var excel = new ExadelExcelValidator(cells);

            await excel.ValidateColumnNames();
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
                throw new ValidationException(string.Join(Environment.NewLine, errors));
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

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static IXLWorksheet CreateWorkSheetWithColumnNames(IXLWorkbook workbook)
        {
            var worksheet = workbook.Worksheets.Add("Producer");
            worksheet.Cell(TABLE_ROW_OFFSET, AUTOPART_NAME_COLUMN_OFFSET + 1).Value = AUTOPART_NAME_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, AUTOPART_PRICE_COLUMN_OFFSET + 1).Value = AUTOPART_PRICE_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, AUTOPART_DESCRIPTION_COLUMN_OFFSET + 1).Value = AUTOPART_DESCRIPTION_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, PRODUCER_NAME_COLUMN_OFFSET + 1).Value = PRODUCER_NAME_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, CAR_MODEL_COLUMN_OFFSET + 1).Value = CAR_MODEL_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, CAR_ISSUE_YEAR_COLUMN_OFFSET + 1).Value = CAR_ISSUE_YEAR_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, CAR_ENGINE_COLUMN_OFFSET + 1).Value = CAR_ENGINE_COLUMN;
            worksheet.Cell(TABLE_ROW_OFFSET, VENDOR_NAME_COLUMN_OFFSET + 1).Value = VENDOR_NAME_COLUMN;

            return worksheet;
        }

        private static void FillWorkSheetWithDataAndAutoSizeColumns(IXLWorksheet workSheet, IList<Autopart> autoparts, int startRow = TABLE_ROW_OFFSET + 1)
        {
            for (var i = 0; i < autoparts.Count; i++)
            {
                for (var j = 0; j < autoparts[i].Cars.Count; j++)
                {
                    for (var k = 0; k < autoparts[i].Vendors.Count; k++)
                    {
                        workSheet.Cell(startRow, AUTOPART_NAME_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Name;
                        workSheet.Cell(startRow, AUTOPART_PRICE_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Price;
                        workSheet.Cell(startRow, AUTOPART_DESCRIPTION_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Description;
                        workSheet.Cell(startRow, PRODUCER_NAME_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Producer.Name;
                        workSheet.Cell(startRow, CAR_MODEL_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Cars.ElementAt(j).Model;
                        workSheet.Cell(startRow, CAR_ISSUE_YEAR_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Cars.ElementAt(j).IssueYear;
                        workSheet.Cell(startRow, CAR_ENGINE_COLUMN_OFFSET + 1).Value =
                            (EngineIdentifiers)autoparts[i].Cars.ElementAt(j).Engine;
                        workSheet.Cell(startRow, VENDOR_NAME_COLUMN_OFFSET + 1).Value =
                            autoparts[i].Vendors.ElementAt(k).Name;
                        startRow++;
                    }
                }
            }

            workSheet.Columns("A", "Z").AdjustToContents();
        }
    }
}
