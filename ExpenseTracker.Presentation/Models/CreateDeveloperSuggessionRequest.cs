namespace Presentation.Models
{
    public sealed record CreateDeveloperSuggessionRequest(
          string UserId,
          string AppName,
          string Message
    );
}
