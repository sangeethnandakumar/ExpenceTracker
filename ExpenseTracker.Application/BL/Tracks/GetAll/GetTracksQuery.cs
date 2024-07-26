using Application.Dtos;
using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.GetAll
{
    public sealed class GetTracksQuery : IRequest<Result<IEnumerable<TrackDto>>>
    {
        public string Start { get; set; }
        public string End { get; set; }
    }
}
