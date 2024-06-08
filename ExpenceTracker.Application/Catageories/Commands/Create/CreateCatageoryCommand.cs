using LanguageExt.Common;
using MediatR;

namespace Application.Catageories.Commands.Create
{
    public record CreateCatageoryCommand(
        string Name,
        string Description,
        string Icon
        ) : IRequest<Result<Guid>>;
}
