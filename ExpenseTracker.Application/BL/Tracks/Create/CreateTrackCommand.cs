using LanguageExt.Common;
using MediatR;

namespace Application.BL.Tracks.Create
{
    public sealed record CreateTrackCommand(
          int Exp,
          int Inc,
          string Notes,
          string Category
    ) : IRequest<Result<Guid>>;


}
