using FluentValidation;

namespace Application.BL.DeveloperSuggestions.Create
{
    public sealed class CreateDeveloperSuggestionCommandValidator : AbstractValidator<CreateDeveloperSuggestionCommand>
    {
        public CreateDeveloperSuggestionCommandValidator()
        {
            RuleFor(x => x.UserId)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.AppName)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Message)
                    .NotEmpty().WithMessage("Is required.");
        }

    }
}
