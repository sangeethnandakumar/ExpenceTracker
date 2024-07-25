using Application.Constants;
using FluentValidation;
using System.Globalization;

namespace Application.BL.Reports.Get
{
    public sealed class GetReportQueryValidator : AbstractValidator<GenerateReportQuery>
    {
        public GetReportQueryValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Start)
                .NotEmpty().WithMessage("Is required.")
                .Must(BeAValidDate()).WithMessage("Must be a valid date in " + ValidatorConstants.DATE_FORMAT_NAME + " (" + ValidatorConstants.DATE_FORMAT + ") format.");

            RuleFor(x => x.End)
                 .NotEmpty().WithMessage("Is required.")
                 .Must(BeAValidDate()).WithMessage("Must be a valid date in " + ValidatorConstants.DATE_FORMAT_NAME + " (" + ValidatorConstants.DATE_FORMAT + ") format.");

            RuleFor(x => x)
               .Must(BeUnderLimitedRange)
               .WithName("Start & End")
               .WithMessage("Instant reports are supported only upto 3 months from your start date");
        }

        private bool BeUnderLimitedRange(GenerateReportQuery query)
        {
            if (!string.IsNullOrEmpty(query.End) && !string.IsNullOrEmpty(query.Start))
            {
                // Parse the start and end dates
                DateTime startDate = DateTime.ParseExact(query.Start, ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(query.End, ValidatorConstants.DATE_FORMAT, CultureInfo.InvariantCulture);

                // Calculate the date 3 months after the start date
                DateTime maxEndDate = startDate.AddMonths(3);

                // Check if the end date is within 3 months of the start date
                if (endDate <= maxEndDate)
                {
                    return true;
                }
            }
            return false;
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
