using Application.AppDBContext;
using Application.Extenions;
using Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Application.Employees.Commands
{
    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<Guid>>
    {
        private readonly ILogger<CreateEmployeeCommandHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IValidator<CreateEmployeeCommand> validator;

        public CreateEmployeeCommandHandler(ILogger<CreateEmployeeCommandHandler> logger, IAppDBContext dbContext, IValidator<CreateEmployeeCommand> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<Guid>(new ValidationException(validationResult.Errors));
            }

            //Create
            var result = await dbContext.Employees.AddAsync(new Employee(
                  request.Name,
                  request.IsDeveloper,
                  request.Age,
                  DateTime.ParseExact(request.Dob, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None)
            ));
            await dbContext.SaveChangesAsync(cancellationToken);

            //Complete
            return result.Entity.Id; ;
        }
    }
}
