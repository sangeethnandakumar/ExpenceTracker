using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Images
{
    public sealed record GetImageQuery(string Id) : IRequest<Result<byte[]>>;
}
