using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.BL.Categories.Create
{
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
    {
        private readonly ILogger<CreateCategoryCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateCategoryCommand> validator;

        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateCategoryCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.Categories.AddAsync(new Category(
                  request.Title,
                  request.Text,
                  request.Sub != null ? Guid.Parse(request.Sub) : null,
                  request.Icon
            ));
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
