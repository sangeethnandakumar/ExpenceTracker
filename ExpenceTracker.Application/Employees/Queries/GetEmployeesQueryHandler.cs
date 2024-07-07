using Application.AppDBContext;
using Application.Dtos;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Employees.Queries
{
    public sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, Result<IEnumerable<EmployeeDto>>>
    {
        private readonly ILogger<GetEmployeesQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetEmployeesQuery> validator;


        public GetEmployeesQueryHandler(ILogger<GetEmployeesQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetEmployeesQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<IEnumerable<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                foreach (var error in validationResult.Errors)
                {
                    logger.LogError(error.ErrorMessage);
                }
                return new Result<IEnumerable<EmployeeDto>>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.Employees.ToListAsync();
            var result = mapper.Map<IEnumerable<EmployeeDto>>(queryResult);

            //Complete
            return new Result<IEnumerable<EmployeeDto>>(result);
        }
    }

}
