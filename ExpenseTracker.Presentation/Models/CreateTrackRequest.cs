namespace Presentation.Models
{
    public sealed record CreateTrackRequest(
          int Exp,
          int Inc,
          string Notes,
          string Category
    );
}
