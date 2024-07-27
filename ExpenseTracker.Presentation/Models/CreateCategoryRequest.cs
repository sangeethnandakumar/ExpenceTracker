namespace Presentation.Models
{
    public sealed record CreateCategoryRequest(
      string Title,
      string Text,
      string Icon,
      string Color,
      string CustomImage
);
}
