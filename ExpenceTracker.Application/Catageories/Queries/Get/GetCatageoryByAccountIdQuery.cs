using Domain.Entities;
using MediatR;

namespace Application.Catageories.Queries.Get
{
    public record GetCatageoryByAccountIdQuery(Guid Id) : IRequest<IEnumerable<Catageory>>;
}
