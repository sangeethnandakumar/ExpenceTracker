using Application.AppDBContext;
using Application.Catageories.Queries.Get;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Catageories.Queries.GetCatageoriesByUser
{
    public sealed class GetCatageoriesByUserQueryHandler : IRequestHandler<GetCatageoriesByUserQuery, Result<IEnumerable<Catageory>>>
    {
        private readonly ILogger<GetCatageoriesByUserQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetCatageoriesByUserQueryHandler(ILogger<GetCatageoriesByUserQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<Catageory>>> Handle(GetCatageoriesByUserQuery request, CancellationToken cancellationToken)
        {
            var userCatageories = await dbContext.Catageories
                .Where(x => x.AccountId == request.AccountId || x.IsBuiltIn)
                .ToListAsync();
            return userCatageories;
        }
    }
}
