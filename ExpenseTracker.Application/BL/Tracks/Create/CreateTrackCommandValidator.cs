using FluentValidation;

namespace Application.BL.Tracks.Create
{
    public sealed class CreateTrackCommandValidator : AbstractValidator<CreateTrackCommand>
    {
        public CreateTrackCommandValidator()
        {
            RuleFor(x => x.Exp)
                    .InclusiveBetween(0, 1000000).WithMessage("Should be between 0-1000000.");
            RuleFor(x => x.Inc)
                    .InclusiveBetween(0, 1000000).WithMessage("Should be between 0-1000000.");
            RuleFor(x => x.Notes)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Category)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }

    }
}
