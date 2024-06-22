using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Catageories.Queries.Get
{
    public record GetCatageoriesByUserQuery(Guid? AccountId) : IRequest<Result<IEnumerable<Catageory>>>;
}
