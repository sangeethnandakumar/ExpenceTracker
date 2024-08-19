namespace Presentation.Models
{
    public sealed record CreateCategoryRequest(
      string Title,
      string Icon,
      string Color,
      string CustomImage
    );
}
