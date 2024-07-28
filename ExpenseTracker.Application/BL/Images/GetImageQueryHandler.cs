using Application.AppDBContext;
using Application.Extenions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Images
{
    public sealed class GetImageQueryHandler : IRequestHandler<GetImageQuery, Result<byte[]>>
    {
        private readonly ILogger<GetImageQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<GetImageQuery> validator;


        public GetImageQueryHandler(ILogger<GetImageQueryHandler> logger, IAppDBContext dbContext, IValidator<GetImageQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<byte[]>> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<byte[]>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var a = await dbContext.Images.ToListAsync();
            var queryResult = await dbContext.Images.FirstOrDefaultAsync(x => x.MapId == request.Id);
            if (queryResult is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<byte[]>(new DataException($"No data found for id: {request.Id}"));
            }

            //Complete
            return queryResult.Data;
        }
    }
}
