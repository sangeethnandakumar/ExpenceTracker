using Application.AppDBContext;
using Application.Dtos;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries.GetBasicUserById
{
    public sealed class GetBasicUserByIdQueryHandler : IRequestHandler<GetBasicUserByIdQuery, Result<BasicUserDto>>
    {
        private readonly ILogger<GetBasicUserByIdQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetBasicUserByIdQueryHandler(ILogger<GetBasicUserByIdQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<BasicUserDto>> Handle(GetBasicUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users
                .Where(x => x.Id == request.Id)
                .Select(x => new BasicUserDto
                {
                    Id = x.Id,
                    FirstName = x.Name.FirstName,
                    LastName = x.Name.LastName,
                    Email = x.Credential.Email
                })
                .FirstOrDefaultAsync();

            if (user is null)
            {
                return new Result<BasicUserDto>(new Exception("User not found"));
            }

            return user;
        }
    }
}
