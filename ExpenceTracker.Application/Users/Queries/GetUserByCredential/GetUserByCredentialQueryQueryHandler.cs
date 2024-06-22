using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries.GetUserByCredential
{
    public sealed class GetUserByCredentialQueryQueryHandler : IRequestHandler<GetUserByCredentialQuery, Result<User>>
    {
        private readonly ILogger<GetUserByCredentialQueryQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetUserByCredentialQueryQueryHandler(ILogger<GetUserByCredentialQueryQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<User>> Handle(GetUserByCredentialQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x =>
                x.Credential.Email == request.Credential.Email
            );

            if(user is null)
            {
                return new Result<User>(new Exception("Invalid email or password"));
            }

            var isPasswordMatching = BCrypt.Net.BCrypt.Verify(request.Credential.Password, user.Credential.Password);

            if (!isPasswordMatching)
            {
                return new Result<User>(new Exception("Invalid email or password"));
            }

            return user;
        }
    }
}
