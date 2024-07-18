using LanguageExt.Common;
using MediatR;

namespace Application.BL.Categories.Delete
{
    public sealed record DeleteCategoryCommand(string Id) : IRequest<Result<Guid>>;
}
