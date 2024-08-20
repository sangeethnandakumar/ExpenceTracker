using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.DeveloperSuggessions.GetAll
{
    public sealed record GetDeveloperSuggessionsQuery() : IRequest<Result<IEnumerable<DeveloperSuggessionDto>>>;
}
