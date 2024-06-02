using Domain.Abstractions;
using Domain.Users;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.CreateUser
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly ILogger<CreateUserCommandHandler> logger;
        private readonly IUserRepository userRepo;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository userRepo)
        {
            this.logger = logger;
            this.userRepo = userRepo;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Create user
            var user = new User(
                request.FirstName,
                request.LastName,
                request.Username,
                request.DateOfBirth,
                request.LoginMethod,
                request.Gender
                );

            var id = userRepo.CreateUser(user);

            return id;
        }
    }
}
