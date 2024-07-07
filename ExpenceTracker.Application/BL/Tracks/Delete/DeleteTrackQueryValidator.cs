using FluentValidation;

namespace Application.BL.Tracks.Delete
{
    public sealed class DeleteTrackQueryValidator : AbstractValidator<DeleteTrackCommand>
    {
        public DeleteTrackQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
