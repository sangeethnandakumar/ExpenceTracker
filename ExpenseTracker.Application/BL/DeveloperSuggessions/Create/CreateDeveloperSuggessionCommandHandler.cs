using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.BL.DeveloperSuggestions.Create
{
    public sealed class CreateDeveloperSuggestionCommandHandler : IRequestHandler<CreateDeveloperSuggestionCommand, Result<Guid>>
    {
        private readonly ILogger<CreateDeveloperSuggestionCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateDeveloperSuggestionCommand> validator;

        public CreateDeveloperSuggestionCommandHandler(ILogger<CreateDeveloperSuggestionCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateDeveloperSuggestionCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateDeveloperSuggestionCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.DeveloperSuggestions.AddAsync(new DeveloperSuggestion(
                  request.UserId,
                  request.AppName,
                  request.Message
            ));
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
