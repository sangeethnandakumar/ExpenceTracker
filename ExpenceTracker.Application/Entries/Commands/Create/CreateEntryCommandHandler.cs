using Application.AppDBContext;
using Domain.Entities;
using Domain.ValueTypes;
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
            //Create user
            var entry = new Entry(
                    new Amount(request.amount, request.currencycode),
                    Guid.NewGuid()
                    );

            var createEntryResult = await dbContext.Entries.AddAsync(entry);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new Result<Guid>(entry.Id);
        }
    }
}
