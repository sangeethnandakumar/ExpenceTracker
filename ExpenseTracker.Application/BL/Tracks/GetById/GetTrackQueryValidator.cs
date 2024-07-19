using FluentValidation;

namespace Application.BL.Tracks.GetById
{
    public sealed class GetTrackQueryValidator : AbstractValidator<GetTrackQuery>
    {
        public GetTrackQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Is required.")
                .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
