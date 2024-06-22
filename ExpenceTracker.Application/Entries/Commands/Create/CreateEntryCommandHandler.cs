using Application.AppDBContext;
using Domain.Entities;
using Domain.ValueObjects;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Entries.Commands.Create
{
    public sealed class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Result<Guid>>
    {
        private readonly ILogger<CreateEntryCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public CreateEntryCommandHandler(ILogger<CreateEntryCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<Guid>> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var entry = new Entry(
                    request.Amount,
                    request.Note,
                    request.CatageoryId,
                    request.Kind,
                    request.AccountId
                    );

            var createEntryResult = await dbContext.Entries.AddAsync(entry);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Result<Guid>(entry.Id);
        }
    }
}
