using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Update
{
    public sealed record UpdateCategoryCommand(
      string Id,
      string Title,
      string Text,
      string Icon,
      string Color,
      string CustomImage
) : IRequest<Result<Guid>>;
}
