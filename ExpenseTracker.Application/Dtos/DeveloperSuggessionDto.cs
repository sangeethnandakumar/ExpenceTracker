namespace Application.Dtos
{
    public sealed record DeveloperSuggessionDto(
          string UserId,
          string AppName,
          string Message
    );
}
