using Application.Employees.Commands;
using FluentValidation;
using System.Globalization;

namespace Application.Validators
{
    public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.IsDeveloper)
                    .Equal(true).WithMessage("Is required.");
            RuleFor(x => x.Age)
                    .NotEmpty().WithMessage("Is required.").GreaterThan(0).WithMessage("Should be greater than 0.");
            RuleFor(x => x.Dob)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(date => DateTime.TryParseExact(date.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    .WithMessage("Must be a valid date in ISO 8601 (yyyy-MM-ddTHH:mm:ss.fffZ) UTC format.");
        }
    }
}
