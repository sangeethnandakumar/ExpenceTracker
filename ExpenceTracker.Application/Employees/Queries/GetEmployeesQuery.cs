using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Employees.Queries
{
    public sealed record GetEmployeesQuery() : IRequest<Result<IEnumerable<EmployeeDto>>>;
}
