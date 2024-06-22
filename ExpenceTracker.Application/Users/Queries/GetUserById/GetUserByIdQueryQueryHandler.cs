using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries.GetUserById
{
    public sealed class GetUserByIdQueryQueryHandler : IRequestHandler<GetUserByIdQuery, Result<User>>
    {
        private readonly ILogger<GetUserByIdQueryQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetUserByIdQueryQueryHandler(ILogger<GetUserByIdQueryQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user is null)
            {
                return new Result<User>(new Exception("No users found"));
            }

            return user;
        }
    }
}
