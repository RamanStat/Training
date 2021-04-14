using System.IO;
using System.Linq;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Training.Service.Validators
{
    public class FormFileValidator : AbstractValidator<FormFile>
    {
        public static readonly string[] AllowedExtension = {".xls", ".xlsx"};

        public FormFileValidator()
        {
            RuleFor(c => c.FileName)
                .Must(f => AllowedExtension.Contains(Path.GetExtension(f)))
                .WithMessage($"Not a valid extension. The only extensions allowed are {string.Join(", ", AllowedExtension)}");
        }
    }
}
