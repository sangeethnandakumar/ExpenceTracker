namespace Presentation.Models
{
    public sealed record CreateDeveloperSuggestionRequest(
          string UserId,
          string AppName,
          string Message
    );
}
