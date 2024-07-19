namespace Presentation.Models
{
    public sealed record UpdateCategoryRequest(
      string Id,
      string Title,
      string Text,
      string Sub,
      string Icon
);
}
