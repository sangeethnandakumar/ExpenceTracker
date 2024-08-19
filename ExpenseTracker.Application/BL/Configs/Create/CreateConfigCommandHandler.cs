using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.BL.Configs.Create
{
    public sealed class CreateConfigCommandHandler : IRequestHandler<CreateConfigCommand, Result<string>>
    {
        private readonly ILogger<CreateConfigCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateConfigCommand> validator;

        public CreateConfigCommandHandler(ILogger<CreateConfigCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateConfigCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<string>> Handle(CreateConfigCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<string>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.Configs.AddAsync(new ConfigModel(

            ));
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
