using FluentValidation;
using Training.SDK.DTO;

namespace Training.SDK.Validators
{
    class ExcelValidator : AbstractValidator<ExcelDTO>
    {
        public ExcelValidator()
        {
            RuleFor(e => e.AutopartName).Length(3, 40);
            RuleFor(e => e.AutopartPrice).GreaterThan(1);
        }
    }
}
