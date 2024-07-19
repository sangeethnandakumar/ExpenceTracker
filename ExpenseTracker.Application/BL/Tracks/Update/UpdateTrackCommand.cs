using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.Update
{
    public sealed record UpdateTrackCommand(
      string Id,
      string Date,
      int Exp,
      int Inc,
      string Notes,
      string Category
) : IRequest<Result<Guid>>;
}
