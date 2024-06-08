using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Configs.Queries.Get
{
    public sealed class GetConfigQueryHandler : IRequestHandler<GetConfigQuery, Result<Config>>
    {
        private readonly ILogger<GetConfigQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetConfigQueryHandler(ILogger<GetConfigQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public Task<Result<Config>> Handle(GetConfigQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
