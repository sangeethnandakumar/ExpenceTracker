using Application.Constants;
using FluentValidation;
using System.Globalization;

namespace Application.BL.Tracks.GetAll
{
    public sealed class GetTracksQueryValidator : AbstractValidator<GetTracksQuery>
    {
        public GetTracksQueryValidator()
        {
            RuleFor(x => x.Start)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(BeAValidDate())
                    .WithMessage("Must be a valid date in " + ValidatorConstants.DATE_FORMAT_NAME + " (" + ValidatorConstants.DATE_FORMAT + ") format.");
            RuleFor(x => x.End)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(BeAValidDate())
                    .WithMessage("Must be a valid date in " + ValidatorConstants.DATE_FORMAT_NAME + " (" + ValidatorConstants.DATE_FORMAT + ") format.");
        }

        private static Func<string, bool> BeAValidDate()
        {
            return date => DateTime.TryParseExact(
                date,
                ValidatorConstants.DATE_FORMAT,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}
