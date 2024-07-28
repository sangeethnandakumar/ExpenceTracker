using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Create
{
    public sealed record CreateCategoryCommand(
      string Title,
      string Icon,
      string Color,
      string CustomImage
) : IRequest<Result<Guid>>;

}
