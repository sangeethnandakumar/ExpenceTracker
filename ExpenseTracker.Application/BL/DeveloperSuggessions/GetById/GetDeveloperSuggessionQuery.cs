using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggestions.GetById
{
    public sealed record GetDeveloperSuggestionQuery(string Id) : IRequest<Result<DeveloperSuggestionDto>>;
}
