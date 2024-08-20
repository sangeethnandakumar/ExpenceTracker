using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggessions.GetById
{
    public sealed record GetDeveloperSuggessionQuery(string Id) : IRequest<Result<DeveloperSuggessionDto>>;
}
