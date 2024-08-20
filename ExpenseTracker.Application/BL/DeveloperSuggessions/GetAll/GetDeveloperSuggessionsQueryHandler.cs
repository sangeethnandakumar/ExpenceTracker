using Application.AppDBContext;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.BL.DeveloperSuggessions.GetAll
{
    public sealed class GetDeveloperSuggessionsQueryHandler : IRequestHandler<GetDeveloperSuggessionsQuery, Result<IEnumerable<DeveloperSuggessionDto>>>
    {
        private readonly ILogger<GetDeveloperSuggessionsQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetDeveloperSuggessionsQuery> validator;


        public GetDeveloperSuggessionsQueryHandler(ILogger<GetDeveloperSuggessionsQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetDeveloperSuggessionsQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<IEnumerable<DeveloperSuggessionDto>>> Handle(GetDeveloperSuggessionsQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<IEnumerable<DeveloperSuggessionDto>>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.DeveloperSuggessions.ToListAsync();
            var result = mapper.Map<IEnumerable<DeveloperSuggessionDto>>(queryResult);

            //Complete
            return new Result<IEnumerable<DeveloperSuggessionDto>>(result);
        }
    }
}
