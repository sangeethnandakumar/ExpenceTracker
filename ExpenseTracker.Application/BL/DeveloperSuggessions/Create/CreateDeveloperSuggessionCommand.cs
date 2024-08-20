using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggessions.Create
{
    public sealed record CreateDeveloperSuggessionCommand(
          string UserId,
          string AppName,
          string Message
    ) : IRequest<Result<Guid>>;
}
