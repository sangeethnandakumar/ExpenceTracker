using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Entries.Queries.FetchEntries
{
    public sealed record FetchEntriesQuery(
            DateTime startDate,
            DateTime endDate
        ) : IRequest<Result<IEnumerable<Entry>>>;
}
