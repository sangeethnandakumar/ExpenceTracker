using FluentValidation;

namespace Application.BL.Categories.Create
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Is required.");
        }
    }
}
