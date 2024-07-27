using FluentValidation;

namespace Application.BL.Categories.Create
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Text)
                    .NotEmpty().WithMessage("Is required.");

            When(x => string.IsNullOrEmpty(x.CustomImage), () =>
            {
                RuleFor(x => x.Icon)
                    .NotEmpty().WithMessage("Is required.");
            });

            RuleFor(x => x.Color)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.CustomImage)
                    .NotEmpty().WithMessage("Is required.");
        }
    }
}
