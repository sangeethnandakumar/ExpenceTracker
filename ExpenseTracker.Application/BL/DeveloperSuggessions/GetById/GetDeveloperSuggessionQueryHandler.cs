using Application.AppDBContext;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.DeveloperSuggessions.GetById
{
    public sealed class GetDeveloperSuggessionQueryHandler : IRequestHandler<GetDeveloperSuggessionQuery, Result<DeveloperSuggessionDto>>
    {
        private readonly ILogger<GetDeveloperSuggessionQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetDeveloperSuggessionQuery> validator;


        public GetDeveloperSuggessionQueryHandler(ILogger<GetDeveloperSuggessionQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetDeveloperSuggessionQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<DeveloperSuggessionDto>> Handle(GetDeveloperSuggessionQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<DeveloperSuggessionDto>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.DeveloperSuggessions.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            if (queryResult is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<DeveloperSuggessionDto>(new DataException($"No data found for id: {request.Id}"));
            }
            var result = mapper.Map<DeveloperSuggessionDto>(queryResult);

            //Complete
            return result;
        }
    }
}
