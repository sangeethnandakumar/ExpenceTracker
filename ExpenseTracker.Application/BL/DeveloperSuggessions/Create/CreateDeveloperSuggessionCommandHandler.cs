using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.BL.DeveloperSuggessions.Create
{
    public sealed class CreateDeveloperSuggessionCommandHandler : IRequestHandler<CreateDeveloperSuggessionCommand, Result<Guid>>
    {
        private readonly ILogger<CreateDeveloperSuggessionCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateDeveloperSuggessionCommand> validator;

        public CreateDeveloperSuggessionCommandHandler(ILogger<CreateDeveloperSuggessionCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateDeveloperSuggessionCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateDeveloperSuggessionCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.DeveloperSuggessions.AddAsync(new DeveloperSuggession(
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
