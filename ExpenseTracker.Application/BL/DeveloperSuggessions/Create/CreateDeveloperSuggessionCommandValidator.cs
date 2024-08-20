using FluentValidation;

namespace Application.BL.DeveloperSuggessions.Create
{
    public sealed class CreateDeveloperSuggessionCommandValidator : AbstractValidator<CreateDeveloperSuggessionCommand>
    {
        public CreateDeveloperSuggessionCommandValidator()
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
