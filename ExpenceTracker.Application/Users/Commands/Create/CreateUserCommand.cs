using Domain.Enums;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Commands.Create
{
    public record CreateUserCommand(
         string FirstName,
         string LastName,
         string Email,
         LogInMode LogInMode,
         DateOnly? DateOfBirth,
         string Avatar,
         Gender Gender,
         string Country,
         string Password
     ) : IRequest<Result<Guid>>;

}
