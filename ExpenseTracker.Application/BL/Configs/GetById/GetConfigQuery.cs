using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Configs.GetById
{
    public sealed record GetConfigQuery(string Id) : IRequest<Result<ConfigDto>>;
}
