using Domain.Abstractions;
using Domain.Entities;
using Domain.ValueTypes;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using NMoneys;

namespace Application.Entries.Commands.CreateEntry
{
    public sealed class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Result<Guid>>
    {
        private readonly ILogger<CreateEntryCommandHandler> logger;
        private readonly IEntryRepository userRepo;

        public CreateEntryCommandHandler(ILogger<CreateEntryCommandHandler> logger, IEntryRepository userRepo)
        {
            this.logger = logger;
            this.userRepo = userRepo;
        }

        public async Task<Result<Guid>> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            //Create user
            var entry = new Entry(
                    new Amount(request.amount, Currency.Get(request.currencycode)),
                    Guid.NewGuid()
                    );

            var createEntryResult = userRepo.CreateEntry(entry);

            if (createEntryResult.IsFaulted)
            {
                logger.LogDebug($"Unable to create a new entry {createEntryResult}");
                return createEntryResult;
            }

            return createEntryResult;
        }
    }
}
