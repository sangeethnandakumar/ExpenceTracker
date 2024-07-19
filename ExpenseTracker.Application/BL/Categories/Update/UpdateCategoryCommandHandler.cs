using Application.AppDBContext;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Categories.Update
{
    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Guid>>
    {
        private readonly ILogger<UpdateCategoryCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<UpdateCategoryCommand> validator;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(ILogger<UpdateCategoryCommandHandler> logger, IAppDBContext dbContext, IValidator<UpdateCategoryCommand> validator, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Entity To Update
            var entityToUpdate = await dbContext.Categories.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.Id), cancellationToken);
            if (entityToUpdate is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<Guid>(new DataException($"No data found for id: {request.Id}"));
            }

            //Update entity
            mapper.Map(request, entityToUpdate);

            //Update
            var result = dbContext.Categories.Update(entityToUpdate);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
