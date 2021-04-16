using System;
using FluentValidation;
using static Training.Service.Constants.ImportFileOffsets;
using static Training.Service.Constants.ImportFileStructure;

namespace Training.Service.Validators
{
    public class ExcelDataRowsValidator : AbstractValidator<string[]>
    {
        private readonly Func<string, bool> _validateAutopartPrice = 
            price => double.TryParse(price, out var value) && value > 0.0;

        private readonly Func<string, bool> _validateCarIssuerYear = 
            year => int.TryParse(year, out var value) && value >= 1850 && value <= DateTime.Now.Year;

        private readonly Func<string, bool> _validateCarEngine =
            engine => int.TryParse(engine, out var value) && value is >= 0 and <= 2;

        public ExcelDataRowsValidator()
        {
            RuleFor(e => e[AUTOPART_NAME_COLUMN_OFFSET]).NotEmpty().Length(3, 40).OverridePropertyName(AUTOPART_NAME_COLUMN_NAME);
            RuleFor(e => e[AUTOPART_PRICE_COLUMN_OFFSET]).Must(e => _validateAutopartPrice(e)).WithMessage("AUTOPART_PRICE must be greater then 0");
            RuleFor(e => e[AUTOPART_DESCRIPTION_COLUMN_OFFSET]).NotEmpty().MinimumLength(20).OverridePropertyName(AUTOPART_DESCRIPTION_COLUMN_NAME);
            RuleFor(e => e[PRODUCER_NAME_COLUMN_OFFSET]).NotEmpty().Length(3, 40).OverridePropertyName(PRODUCER_NAME_COLUMN_NAME);
            RuleFor(e => e[CAR_MODEL_COLUMN_OFFSET]).NotEmpty().Length(1, 25).OverridePropertyName(CAR_MODEL_COLUMN_NAME);
            RuleFor(e => e[CAR_ISSUE_YEAR_COLUMN_OFFSET]).Must(s => _validateCarIssuerYear(s)).WithMessage($"CAR_ISSUER_YEAR must be between 1850 and {DateTime.Now.Year}");
            RuleFor(e => e[CAR_ENGINE_COLUMN_OFFSET]).Must(s => _validateCarEngine(s)).WithMessage("CAR_ENGINE must be between 0 and 2");
            RuleFor(e => e[VENDOR_NAME_COLUMN_OFFSET]).NotEmpty().Length(3, 40).OverridePropertyName(VENDOR_NAME_COLUMN_NAME);
        }
    }
}
