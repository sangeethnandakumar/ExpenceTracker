using FluentValidation;

namespace Application.BL.Categories.Update
{
    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Text)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Icon)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Color)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.CustomImage)
                    .NotEmpty().WithMessage("Is required.");
        }

    }
}
