using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Configs.GetAll
{
    public sealed record GetConfigsQuery() : IRequest<Result<IEnumerable<ConfigDto>>>;
}
