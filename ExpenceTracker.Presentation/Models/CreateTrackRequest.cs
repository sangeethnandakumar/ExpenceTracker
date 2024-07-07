namespace Presentation.Models
{
    public sealed record CreateTrackRequest(
          string Date,
          int Exp,
          int Inc,
          string Notes,
          string Category
    );
}
