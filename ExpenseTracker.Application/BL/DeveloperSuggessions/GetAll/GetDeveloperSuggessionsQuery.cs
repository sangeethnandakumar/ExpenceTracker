using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggestions.GetAll
{
    public sealed record GetDeveloperSuggestionsQuery() : IRequest<Result<IEnumerable<DeveloperSuggestionDto>>>;
}
