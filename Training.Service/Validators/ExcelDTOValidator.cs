using System;
using FluentValidation;
using Training.SDK.DTO;

namespace Training.Service.Validators
{
    public class ExcelDTOValidator : AbstractValidator<ExcelDTO>
    {
        public ExcelDTOValidator()
        {
            RuleFor(e => e.AutopartName).NotEmpty().Length(3, 40);
            RuleFor(e => e.AutopartPrice).GreaterThan(0);
            RuleFor(e => e.AutopartDescription).NotEmpty().MinimumLength(20);
            RuleFor(e => e.ProducerName).NotEmpty().Length(3, 40);
            RuleFor(e => e.CarModel).NotEmpty().Length(1, 25);
            RuleFor(e => e.CarIssueYear).InclusiveBetween(1850, DateTime.Now.Year);
            RuleFor(e => e.CarEngine).InclusiveBetween(0, 2);
            RuleFor(e => e.VendorName).NotEmpty().Length(3, 40);
        }
    }
}
