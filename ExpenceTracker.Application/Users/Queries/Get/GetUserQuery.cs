using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries.Get
{
    public record GetUserQuery : IRequest<Result<User>>;
}
