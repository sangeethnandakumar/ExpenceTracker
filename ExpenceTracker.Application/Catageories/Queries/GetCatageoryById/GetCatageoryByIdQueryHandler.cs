using Application.AppDBContext;
using Domain.Entities;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Catageories.Queries.GetCatageoryById
{
    public sealed class GetCatageoryByIdQueryHandler : IRequestHandler<GetCatageoryByIdQuery, Result<Catageory>>
    {
        private readonly ILogger<GetCatageoryByIdQueryHandler> logger;
        private readonly IAppDBContext dbContext;

        public GetCatageoryByIdQueryHandler(ILogger<GetCatageoryByIdQueryHandler> logger, IAppDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<Result<Catageory>> Handle(GetCatageoryByIdQuery request, CancellationToken cancellationToken)
        {
            var catageory = await dbContext.Catageories.FirstOrDefaultAsync(x => x.Id == request.Id);
            return catageory;
        }
    }
}
