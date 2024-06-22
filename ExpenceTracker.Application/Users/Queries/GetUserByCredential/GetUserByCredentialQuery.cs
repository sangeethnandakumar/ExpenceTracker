using Domain.Entities;
using Domain.ValueObjects;
using LanguageExt.Common;
using MediatR;

namespace Application.Users.Queries.GetUserByCredential
{
    public record GetUserByCredentialQuery(Credential Credential) : IRequest<Result<User>>;
}
