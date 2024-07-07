using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.GetById
{
    public sealed record GetTrackQuery(string Id) : IRequest<Result<TrackDto>>;
}
