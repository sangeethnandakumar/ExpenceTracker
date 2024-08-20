namespace Application.Dtos
{
    public sealed record DeveloperSuggestionDto(
          string UserId,
          string AppName,
          string Message
    );
}
