using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.Delete
{
    public sealed record DeleteTrackCommand(string Id) : IRequest<Result<Guid>>;
}
