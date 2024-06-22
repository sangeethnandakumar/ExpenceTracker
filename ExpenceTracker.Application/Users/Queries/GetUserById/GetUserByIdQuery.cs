using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<Result<User>>;
}
