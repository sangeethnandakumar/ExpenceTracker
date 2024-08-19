using Application.AppDBContext;
using Application.Extenions;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.BL.Configs.Update
{
    public sealed class UpdateConfigCommandHandler : IRequestHandler<UpdateConfigCommand, Result<string>>
    {
        private readonly ILogger<UpdateConfigCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<UpdateConfigCommand> validator;
        private readonly IMapper mapper;

        public UpdateConfigCommandHandler(ILogger<UpdateConfigCommandHandler> logger, IAppDBContext dbContext, IValidator<UpdateConfigCommand> validator, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<Result<string>> Handle(UpdateConfigCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<string>(new ValidationException(validationResult.Errors));
            }

            //Entity To Update
            var entityToUpdate = await dbContext.Configs.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
            if (entityToUpdate is null)
            {
                //Create
                var newEntity = mapper.Map<ConfigModel>(request);
                await dbContext.Configs.AddAsync(newEntity);
                await dbContext.SaveChangesAsync(cancellationToken);
                return newEntity.Id;
            }

            //Update entity
            mapper.Map(request, entityToUpdate);

            //Update
            var result = dbContext.Configs.Update(entityToUpdate);
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id;
        }
    }
}
