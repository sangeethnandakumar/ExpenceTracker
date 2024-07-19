using Application.AppDBContext;
using Application.Dtos;
using Application.Extenions;
using AutoMapper;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Application.BL.Categories.GetById
{
    public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result<CategoryDto>>
    {
        private readonly ILogger<GetCategoryQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetCategoryQuery> validator;


        public GetCategoryQueryHandler(ILogger<GetCategoryQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetCategoryQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<CategoryDto>(new ValidationException(validationResult.Errors));
            }

            //Proceed
            var queryResult = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == Guid.Parse(request.Id));
            if (queryResult is null)
            {
                logger.LogInformation("No data found for id: {@Id}", request.Id);
                return new Result<CategoryDto>(new DataException($"No data found for id: {request.Id}"));
            }
            var result = mapper.Map<CategoryDto>(queryResult);

            //Complete
            return result;
        }
    }
}
