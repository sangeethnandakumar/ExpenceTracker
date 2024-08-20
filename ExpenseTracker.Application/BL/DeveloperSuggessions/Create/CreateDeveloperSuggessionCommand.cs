using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggestions.Create
{
    public sealed record CreateDeveloperSuggestionCommand(
          string UserId,
          string AppName,
          string Message
    ) : IRequest<Result<Guid>>;
}
