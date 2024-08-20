using FluentValidation;

namespace Application.BL.DeveloperSuggessions.GetById
{
    public sealed class GetDeveloperSuggessionQueryValidator : AbstractValidator<GetDeveloperSuggessionQuery>
    {
        public GetDeveloperSuggessionQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
