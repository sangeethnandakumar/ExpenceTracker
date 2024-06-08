using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Entries.Queries.Get
{
    public sealed record GetEntriesQuery(
            DateTime startDate,
            DateTime endDate
        ) : IRequest<Result<IEnumerable<Entry>>>;
}
