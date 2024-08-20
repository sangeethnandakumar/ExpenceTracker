using Application.AppDBContext;
using Application.Extenions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.DeveloperSuggessions.Delete
{
    public sealed class DeleteDeveloperSuggessionCommandHandler : IRequestHandler<DeleteDeveloperSuggessionCommand, Result<Guid>>
    {
        private readonly ILogger<DeleteDeveloperSuggessionCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<DeleteDeveloperSuggessionCommand> validator;

        public DeleteDeveloperSuggessionCommandHandler(ILogger<DeleteDeveloperSuggessionCommandHandler> logger, IAppDBContext dbContext, IValidator<DeleteDeveloperSuggessionCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(DeleteDeveloperSuggessionCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Entity To Delete
            var entityToDelete = await dbContext.DeveloperSuggessions.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.Id), cancellationToken);
            if (entityToDelete is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<Guid>(new DataException($"No data found for id: {request.Id}"));
            }

            //Delete
            var result = dbContext.DeveloperSuggessions.Remove(entityToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
