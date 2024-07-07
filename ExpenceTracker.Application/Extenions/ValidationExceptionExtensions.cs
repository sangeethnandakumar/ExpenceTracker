using FluentValidation.Results;

namespace Application.Extenions
{
    public static class ValidationExceptionExtensions
    {
        public static Dictionary<string, List<string>> ToStandardDictionary(this ValidationResult result)
        {
            var errors = result.Errors
                   .GroupBy(e => e.PropertyName)
                   .ToDictionary(
                       g => g.Key,
                       g => g.Select(e => e.ErrorMessage).ToList()
                   );
            return errors;
        }
    }
}
