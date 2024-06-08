using Application.AppDBContext;
using Application.Entries.Commands.Create;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Entries.Queries.Get
{
    public sealed class GetEntriesQueryHandler : IRequestHandler<GetEntriesQuery, Result<IEnumerable<Entry>>>
    {
        private readonly ILogger<CreateEntryCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetEntriesQueryHandler(ILogger<CreateEntryCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<Entry>>> Handle(GetEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await dbContext.Entries.Where(x => x.CreatedOn >= request.startDate && x.CreatedOn <= request.endDate).ToListAsync();
            return entries;
        }
    }
}
