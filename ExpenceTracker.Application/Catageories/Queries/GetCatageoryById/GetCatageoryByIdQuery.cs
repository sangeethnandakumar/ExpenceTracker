using Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace Application.Catageories.Queries.GetCatageoryById
{
    public record GetCatageoryByIdQuery(Guid Id) : IRequest<Result<Catageory>>;
}
