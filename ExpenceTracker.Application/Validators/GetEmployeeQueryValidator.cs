using Application.Employees.Queries;
using FluentValidation;

namespace Application.Validators
{
    public sealed class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
    {
        public GetEmployeeQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
