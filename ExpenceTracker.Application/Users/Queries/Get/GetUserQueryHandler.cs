using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Users.Queries.Get
{
    public sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<User>>
    {
        private readonly ILogger<GetUserQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetUserQueryHandler(ILogger<GetUserQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Task<Result<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
