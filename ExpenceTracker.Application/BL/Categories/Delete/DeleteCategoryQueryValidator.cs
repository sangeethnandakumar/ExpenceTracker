using FluentValidation;

namespace Application.BL.Categories.Delete
{
    public sealed class DeleteCategoryQueryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
