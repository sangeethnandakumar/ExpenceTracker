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

namespace Application.BL.Categories.GetAll
{
    public sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<IEnumerable<CategoryDto>>>
    {
        private readonly ILogger<GetCategoriesQueryHandler> logger;
        private readonly IAppDBContext dbContext;
        private readonly IMapper mapper;
        private readonly IValidator<GetCategoriesQuery> validator;


        public GetCategoriesQueryHandler(ILogger<GetCategoriesQueryHandler> logger, IAppDBContext dbContext, IMapper mapper, IValidator<GetCategoriesQuery> validator)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<Result<IEnumerable<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            //Validate
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                logger.LogInformation("Validation errors: {@ValidationErrors}", validationResult.ToStandardDictionary());
                return new Result<IEnumerable<CategoryDto>>(new ValidationException(validationResult.Errors));
            }

            // Fetch tracks into memory
            var tracks = await dbContext.Tracks
                .OrderByDescending(t => t.Date)
                .ToListAsync();

            // Group by category and order by most recent usage
            var recentCategoryIds = tracks
                .GroupBy(t => t.Category)
                .Select(g => new { CategoryId = g.Key, LastUsed = g.Max(t => t.Date) })
                .OrderByDescending(g => g.LastUsed)
                .Select(g => g.CategoryId)
                .ToList();

            // Fetch categories
            var categories = await dbContext.Categories
                .Where(c => recentCategoryIds.Contains(c.Id))
                .ToListAsync();

            // Sort categories by recent usage
            var sortedCategories = categories
                .OrderBy(c => recentCategoryIds.IndexOf(c.Id))
                .ToList();

            // Map to DTOs
            var result = mapper.Map<IEnumerable<CategoryDto>>(sortedCategories);

            //Complete
            return new Result<IEnumerable<CategoryDto>>(result);
        }
    }
}
