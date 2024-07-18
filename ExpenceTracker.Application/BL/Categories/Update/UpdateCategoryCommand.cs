using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Update
{
    public sealed record UpdateCategoryCommand(
      string Id,
      string Title,
      string Text,
      string Sub,
      string Icon
) : IRequest<Result<Guid>>;
}
