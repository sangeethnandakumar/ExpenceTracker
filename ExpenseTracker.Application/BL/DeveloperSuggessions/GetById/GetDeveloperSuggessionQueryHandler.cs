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

namespace Application.BL.DeveloperSuggestions.GetById
{
    public sealed class GetDeveloperSuggestionQueryHandler : IRequestHandler<GetDeveloperSuggestionQuery, Result<DeveloperSuggestionDto>>
    {
        private readonly ILogger<GetDeveloperSuggestionQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetDeveloperSuggestionQuery> validator;


        public GetDeveloperSuggestionQueryHandler(ILogger<GetDeveloperSuggestionQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetDeveloperSuggestionQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<DeveloperSuggestionDto>> Handle(GetDeveloperSuggestionQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<DeveloperSuggestionDto>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.DeveloperSuggestions.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            if (queryResult is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<DeveloperSuggestionDto>(new DataException($"No data found for id: {request.Id}"));
            }
            var result = mapper.Map<DeveloperSuggestionDto>(queryResult);

            //Complete
            return result;
        }
    }
}
