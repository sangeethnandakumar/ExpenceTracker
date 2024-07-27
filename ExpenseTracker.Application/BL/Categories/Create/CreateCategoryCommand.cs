using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Create
{
    public sealed record CreateCategoryCommand(
      string Title,
      string Text,
      string Icon,
      string Color,
      string CustomImage
) : IRequest<Result<Guid>>;

}
