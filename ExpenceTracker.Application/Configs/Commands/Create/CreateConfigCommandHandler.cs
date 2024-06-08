using Application.AppDBContext;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Configs.Commands.Create
{
    public sealed class CreateConfigCommandHandler : IRequestHandler<CreateConfigCommand>
    {
        private readonly ILogger<CreateConfigCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public CreateConfigCommandHandler(ILogger<CreateConfigCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Task Handle(CreateConfigCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
