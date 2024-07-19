using FluentValidation;
using Presentation.Models;

namespace Presentation.Extensions
{
    public static class ValidationExceptionExtensions
    {
        public static StandardValidationError ToStandardResponse(this ValidationException exception)
        {
            var errors = exception.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToList()
                );

            return new StandardValidationError
            {
                Errors = errors
            };
        }

        public static StandardValidationError ToStandardResponse(this Exception exception)
        {
            return new StandardValidationError
            {
                Message = exception.Message
            };
        }
    }
}
