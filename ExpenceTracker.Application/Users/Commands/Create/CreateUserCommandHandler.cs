using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Commands.Create
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
    {
        private readonly ILogger<CreateUserCommandHandler> logger;
        private readonly IAppDBContext dbContext;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await dbContext.Users.AnyAsync(x => x.Credential.Email == request.Email);

            if (existingUser)
            {
                return new Result<Guid>(new Exception("Invalid Email Address"));
            }

            var newUser = User.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.LogInMode,
                request.Password,
                request.DateOfBirth,
                request.Gender,
                request.Country);

            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newUser.Id;
        }
    }
}
