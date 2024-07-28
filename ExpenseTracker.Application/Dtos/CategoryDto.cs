namespace Application.Dtos
{
    public sealed record CategoryDto(
      string Id,
      string Title,
      string Icon,
      string Color,
      string CustomImage
);
}
