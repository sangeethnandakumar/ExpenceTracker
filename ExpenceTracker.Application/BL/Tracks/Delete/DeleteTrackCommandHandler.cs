using Application.AppDBContext;
using Application.Extenions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Tracks.Delete
{
    public sealed class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, Result<Guid>>
    {
        private readonly ILogger<DeleteTrackCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<DeleteTrackCommand> validator;

        public DeleteTrackCommandHandler(ILogger<DeleteTrackCommandHandler> logger, IAppDBContext dbContext, IValidator<DeleteTrackCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(DeleteTrackCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Entity To Delete
            var entityToDelete = await dbContext.Tracks.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.Id), cancellationToken);
            if (entityToDelete is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<Guid>(new DataException($"No data found for id: {request.Id}"));
            }

            //Delete
            var result = dbContext.Tracks.Remove(entityToDelete);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
