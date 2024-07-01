using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries.GetBasicUserById
{
    public sealed record GetBasicUserByIdQuery(Guid Id) : IRequest<Result<BasicUserDto>>;
}
