using FluentValidation;
using System.Globalization;

namespace Application.BL.Tracks.Update
{
    public sealed class UpdateTrackCommandValidator : AbstractValidator<UpdateTrackCommand>
    {
        public UpdateTrackCommandValidator()
        {
            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
            RuleFor(x => x.Date)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(date => DateTime.TryParseExact(date.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    .WithMessage("Must be a valid date in ISO 8601 (yyyy-MM-ddTHH:mm:ss.fffZ) UTC format.");
            RuleFor(x => x.Exp)
                    .InclusiveBetween(0, 1000).WithMessage("Should be between 0-1000.");
            RuleFor(x => x.Inc)
                    .InclusiveBetween(0, 1000).WithMessage("Should be between 0-1000.");
            RuleFor(x => x.Notes)
                    .NotEmpty().WithMessage("Is required.");
            RuleFor(x => x.Category)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(id => Guid.TryParse(id, out _)).WithMessage("Must be a valid GUID.");
        }
    }
}
