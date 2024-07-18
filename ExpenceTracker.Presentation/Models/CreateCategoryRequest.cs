namespace Presentation.Models
{
    public sealed record CreateCategoryRequest(
      string Title,
      string Text,
      string Sub,
      string Icon
);
}
