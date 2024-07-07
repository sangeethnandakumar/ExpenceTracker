using Application.Employees.Queries;
using FluentValidation;

namespace Application.Validators
{
    public sealed class GetEmployeesQueryValidator : AbstractValidator<GetEmployeesQuery>
    {
        public GetEmployeesQueryValidator()
        {
        }
    }
}
