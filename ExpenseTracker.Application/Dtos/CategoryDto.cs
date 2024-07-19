namespace Application.Dtos
{
    public sealed record CategoryDto(
          string Id,
          string Title,
          string Text,
          string Sub,
          string Icon
    );
}
