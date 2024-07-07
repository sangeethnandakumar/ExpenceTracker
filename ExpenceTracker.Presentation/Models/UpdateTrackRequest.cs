namespace Presentation.Models
{
    public sealed record UpdateTrackRequest(
           string Id,
           string Date,
           int Exp,
           int Inc,
           string Notes,
           string Category
     );
}
