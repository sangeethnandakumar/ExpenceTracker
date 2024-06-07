using Application.AppDBContext;
using Application.Entries.Commands.CreateEntry;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Entries.Queries.FetchEntries
{
    public sealed class FetchEntriesQueryHandler : IRequestHandler<FetchEntriesQuery, Result<IEnumerable<Entry>>>
    {
        private readonly ILogger<CreateEntryCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public FetchEntriesQueryHandler(ILogger<CreateEntryCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<Entry>>> Handle(FetchEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await dbContext.Entries.Where(x => x.CreatedOn >= request.startDate && x.CreatedOn <= request.endDate).ToListAsync();
            return entries;
        }
    }
}
