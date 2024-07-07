using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks
{
    public sealed record GetTrackQuery(string Id) : IRequest<Result<TrackDto>>;
}
