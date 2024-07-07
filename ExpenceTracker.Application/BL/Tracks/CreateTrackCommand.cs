using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks
{
    public sealed record CreateTrackCommand(
          string Date,
          int Exp,
          int Inc,
          string Notes,
          string Category
    ) : IRequest<Result<Guid>>;
}
