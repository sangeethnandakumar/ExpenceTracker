using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Configs.Queries.Get
{
    public record GetConfigQuery : IRequest<Result<Config>>;
}
