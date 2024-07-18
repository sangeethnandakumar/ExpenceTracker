using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Create
{
    public sealed record CreateCategoryCommand(
      string Title,
      string Text,
      string Sub,
      string Icon
) : IRequest<Result<Guid>>;
}
