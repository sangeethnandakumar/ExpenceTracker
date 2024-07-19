using Application.AppDBContext;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Tracks.Update
{

    public sealed class UpdateTrackCommandHandler : IRequestHandler<UpdateTrackCommand, Result<Guid>>
    {
        private readonly ILogger<UpdateTrackCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<UpdateTrackCommand> validator;
        private readonly IMapper mapper;

        public UpdateTrackCommandHandler(ILogger<UpdateTrackCommandHandler> logger, IAppDBContext dbContext, IValidator<UpdateTrackCommand> validator, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateTrackCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Entity To Update
            var entityToUpdate = await dbContext.Tracks.FirstOrDefaultAsync(t => t.Id == Guid.Parse(request.Id), cancellationToken);
            if (entityToUpdate is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<Guid>(new DataException($"No data found for id: {request.Id}"));
            }

            //Update entity
            mapper.Map(request, entityToUpdate);

            //Update
            var result = dbContext.Tracks.Update(entityToUpdate);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
