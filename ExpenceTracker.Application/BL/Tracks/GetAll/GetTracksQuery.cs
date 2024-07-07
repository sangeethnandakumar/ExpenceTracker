using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.GetAll
{
    public sealed record GetTracksQuery() : IRequest<Result<IEnumerable<TrackDto>>>;
}
