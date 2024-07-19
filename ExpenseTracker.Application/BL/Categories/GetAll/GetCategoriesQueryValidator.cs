using FluentValidation;

namespace Application.BL.Categories.GetAll
{
    public sealed class GetCategoriesQueryValidator : AbstractValidator<GetCategoriesQuery>
    {
        public GetCategoriesQueryValidator()
        {
        }
    }
}
