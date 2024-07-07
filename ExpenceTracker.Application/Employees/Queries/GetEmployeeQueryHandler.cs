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
    public sealed class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<EmployeeDto>>
    {
        private readonly ILogger<GetEmployeeQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetEmployeeQuery> validator;


        public GetEmployeeQueryHandler(ILogger<GetEmployeeQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetEmployeeQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
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
                return new Result<EmployeeDto>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            var result = mapper.Map<EmployeeDto>(queryResult);

            //Complete
            return result;
        }
    }

}
