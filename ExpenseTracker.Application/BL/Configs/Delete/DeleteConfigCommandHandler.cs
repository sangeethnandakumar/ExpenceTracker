using Application.AppDBContext;
using Application.Extenions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Configs.Delete
{
    public sealed class DeleteConfigCommandHandler : IRequestHandler<DeleteConfigCommand, Result<string>>
    {
        private readonly ILogger<DeleteConfigCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<DeleteConfigCommand> validator;

        public DeleteConfigCommandHandler(ILogger<DeleteConfigCommandHandler> logger, IAppDBContext dbContext, IValidator<DeleteConfigCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<string>> Handle(DeleteConfigCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<string>(new ValidationException(validationResult.Errors));
            }

            //Entity To Delete
            var entityToDelete = await dbContext.Configs.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (entityToDelete is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<string>(new DataException($"No data found for id: {request.Id}"));
            }

            //Delete
            var result = dbContext.Configs.Remove(entityToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
