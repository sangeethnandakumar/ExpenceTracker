using LanguageExt.Common;
using MediatR;

namespace Application.Employees.Commands
{
    public sealed record CreateEmployeeCommand(
          string Name,
          bool IsDeveloper,
          int Age,
          string Dob
    ) : IRequest<Result<Guid>>;
}
