using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggessions.Delete
{
    public sealed record DeleteDeveloperSuggessionCommand(string Id) : IRequest<Result<Guid>>;
}
