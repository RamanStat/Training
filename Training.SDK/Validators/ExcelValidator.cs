using FluentValidation;
using Training.SDK.DTO;

namespace Training.SDK.Validators
{
    class ExcelValidator : AbstractValidator<ExcelDTO>
    {
        public ExcelValidator()
        {
            RuleFor(e => e.AutopartName).NotNull();
        }
    }
}
