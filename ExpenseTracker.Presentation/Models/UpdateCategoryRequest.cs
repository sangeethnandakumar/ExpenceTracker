namespace Presentation.Models
{
    public sealed record UpdateCategoryRequest(
      string Title,
      string Text,
      string Icon,
      string Color,
      string CustomImage
);
}
