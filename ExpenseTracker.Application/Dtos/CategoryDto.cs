namespace Application.Dtos
{
    public sealed record CategoryDto(
      string Id,
      string Title,
      string Text,
      string Icon,
      string Color,
      string CustomImage
);
}
