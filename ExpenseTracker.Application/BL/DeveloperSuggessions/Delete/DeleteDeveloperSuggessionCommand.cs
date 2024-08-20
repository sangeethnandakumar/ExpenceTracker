using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggestions.Delete
{
    public sealed record DeleteDeveloperSuggestionCommand(string Id) : IRequest<Result<Guid>>;
}
