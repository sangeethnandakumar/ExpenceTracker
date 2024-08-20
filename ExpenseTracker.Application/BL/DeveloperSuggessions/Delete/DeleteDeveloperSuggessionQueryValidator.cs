using FluentValidation;

namespace Application.BL.DeveloperSuggestions.Delete
{
    public sealed class DeleteDeveloperSuggestionQueryValidator : AbstractValidator<DeleteDeveloperSuggestionCommand>
    {
        public DeleteDeveloperSuggestionQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
