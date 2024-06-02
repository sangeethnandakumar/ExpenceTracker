using Domain.Enums;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public record CreateUserCommand(
        string FirstName,
        string? LastName,
        string Username,
        DateTime? DateOfBirth,
        LoginMethod LoginMethod,
        Gender? Gender)
        : IRequest<Result<Guid>>;
}
