using FluentValidation;
using System.Globalization;

namespace Application.BL.Reports.Get
{
    public sealed class GetReportQueryValidator : AbstractValidator<GenerateReportQuery>
    {
        public GetReportQueryValidator()
        {
            RuleFor(x => x.Start)
                .NotEmpty().WithMessage("Is required.")
                .Must(date => DateTime.TryParseExact(date.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                .WithMessage("Must be a valid date in ISO 8601 (yyyy-MM-ddTHH:mm:ss.fffZ) UTC format.");
            RuleFor(x => x.End)
                    .NotEmpty().WithMessage("Is required.")
                    .Must(date => DateTime.TryParseExact(date.ToString(), "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                    .WithMessage("Must be a valid date in ISO 8601 (yyyy-MM-ddTHH:mm:ss.fffZ) UTC format.");
        }
    }
}
