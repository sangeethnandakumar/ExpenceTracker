using Application.AppDBContext;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.Create
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly ILogger<CreateUserCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
