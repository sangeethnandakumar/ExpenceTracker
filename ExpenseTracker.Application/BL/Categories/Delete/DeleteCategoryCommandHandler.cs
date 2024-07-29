using Application.AppDBContext;
using Application.Extenions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Categories.Delete
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<Guid>>
    {
        private readonly ILogger<DeleteCategoryCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<DeleteCategoryCommand> validator;

        public DeleteCategoryCommandHandler(ILogger<DeleteCategoryCommandHandler> logger, IAppDBContext dbContext, IValidator<DeleteCategoryCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Entity To Delete
            var categoryToDelete = await dbContext.Categories.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.Id), cancellationToken);
            if (categoryToDelete is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<Guid>(new DataException($"No data found for id: {request.Id}"));
            }

            //Discover            
            var associatedTracks = await dbContext.Tracks.Where(x=>x.Category == categoryToDelete.Id).ToListAsync();
            var associatedImages = await dbContext.Images.Where(x=>x.MapId == categoryToDelete.CustomImage).ToListAsync();

            //Delete
            var result = dbContext.Categories.Remove(categoryToDelete);
            dbContext.Tracks.RemoveRange(associatedTracks);
            dbContext.Images.RemoveRange(associatedImages);

            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
