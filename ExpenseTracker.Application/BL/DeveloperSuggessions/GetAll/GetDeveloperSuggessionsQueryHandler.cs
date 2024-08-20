using Application.AppDBContext;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.BL.DeveloperSuggestions.GetAll
{
    public sealed class GetDeveloperSuggestionsQueryHandler : IRequestHandler<GetDeveloperSuggestionsQuery, Result<IEnumerable<DeveloperSuggestionDto>>>
    {
        private readonly ILogger<GetDeveloperSuggestionsQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetDeveloperSuggestionsQuery> validator;


        public GetDeveloperSuggestionsQueryHandler(ILogger<GetDeveloperSuggestionsQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetDeveloperSuggestionsQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<IEnumerable<DeveloperSuggestionDto>>> Handle(GetDeveloperSuggestionsQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<IEnumerable<DeveloperSuggestionDto>>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.DeveloperSuggestions.ToListAsync();
            var result = mapper.Map<IEnumerable<DeveloperSuggestionDto>>(queryResult);

            //Complete
            return new Result<IEnumerable<DeveloperSuggestionDto>>(result);
        }
    }
}
