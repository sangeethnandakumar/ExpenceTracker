using LanguageExt.Common;
using MediatR;

namespace Application.Catageories.Commands.Create
{
    public record CreateCatageoryCommand(
        string Name,
        string? Description,
        string? Icon,
        bool IsBuiltIn,
        Guid? ParentCatageory,
        Guid? AccountId
        ) : IRequest<Result<Guid>>;
}
