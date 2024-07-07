namespace Presentation.Models
{
    public sealed record StandardValidationError
    {
        public string Message { get; init; } = "Operation failed due to validation errors. Please review the errors and try again.";
        public Dictionary<string, List<string>> Errors { get; init; } = new();
    }
}
