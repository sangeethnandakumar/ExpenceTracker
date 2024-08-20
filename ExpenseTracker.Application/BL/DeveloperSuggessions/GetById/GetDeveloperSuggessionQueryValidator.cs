using FluentValidation;

namespace Application.BL.DeveloperSuggestions.GetById
{
    public sealed class GetDeveloperSuggestionQueryValidator : AbstractValidator<GetDeveloperSuggestionQuery>
    {
        public GetDeveloperSuggestionQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
