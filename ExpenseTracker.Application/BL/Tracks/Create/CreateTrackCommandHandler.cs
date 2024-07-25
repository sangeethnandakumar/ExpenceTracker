using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Application.BL.Tracks.Create
{
    public sealed class CreateTrackCommandHandler : IRequestHandler<CreateTrackCommand, Result<Guid>>
    {
        private readonly ILogger<CreateTrackCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateTrackCommand> validator;

        public CreateTrackCommandHandler(ILogger<CreateTrackCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateTrackCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.Tracks.AddAsync(new Track(
                  DateTime.UtcNow,
                  request.Exp,
                  request.Inc,
                  request.Notes,
                  Guid.Parse(request.Category)
            ));
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
