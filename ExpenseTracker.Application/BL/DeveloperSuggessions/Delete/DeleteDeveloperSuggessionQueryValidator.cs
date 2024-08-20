using FluentValidation;

namespace Application.BL.DeveloperSuggessions.Delete
{
    public sealed class DeleteDeveloperSuggessionQueryValidator : AbstractValidator<DeleteDeveloperSuggessionCommand>
    {
        public DeleteDeveloperSuggessionQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
