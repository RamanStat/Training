using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Training.Service.ExcelValidator.ConcreteExcel
{
    public class ExadelExcelValidator : ExcelValidator
    {
        public ExadelExcelValidator(string[] cells) : base(cells)
        {
        }

        public override void ValidateColumnNames()
        {
            var errors = new List<string>()
            {
                ValidateAutopartName(),
                ValidateAutopartDescription(),
                ValidateAutopartPrice(),
                ValidateCarModel(),
                ValidateCarModel(),
                ValidateCarIssuerYear(),
                ValidateCarEngine(),
                ValidateProducerName(),
                ValidateVendorName(),
            }
                .Where(s => s != null)
                .ToList();

            if (errors.Count != 0)
            {
                throw new ValidationException(string.Join("\n", errors));
            }
        }
    }
}
