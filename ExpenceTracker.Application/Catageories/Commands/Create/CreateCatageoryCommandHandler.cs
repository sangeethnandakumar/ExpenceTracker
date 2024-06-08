using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Catageories.Commands.Create
{
    public sealed class CreateCatageoryCommandHandler : IRequestHandler<CreateCatageoryCommand, Result<Guid>>
    {
        private readonly ILogger<CreateCatageoryCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public CreateCatageoryCommandHandler(ILogger<CreateCatageoryCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<Guid>> Handle(CreateCatageoryCommand request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Catageories.AddAsync(new Catageory(
                request.Name,
                request.Description,
                false,
                request.Description,
                Guid.NewGuid()));

            await dbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}
