using FluentValidation;

namespace Application.BL.Categories.Update
{
    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
            RuleFor(x => x.Title)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Text)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Sub)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
            RuleFor(x => x.Icon)
                    .NotEmpty().WithMessage("Is required.");
        }
    }
}
