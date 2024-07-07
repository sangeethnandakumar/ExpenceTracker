using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Employees.Queries
{
    public sealed record GetEmployeeQuery(string Id) : IRequest<Result<EmployeeDto>>;
}
