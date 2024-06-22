using Domain.Enums;
using Domain.ValueObjects;

namespace Presentation.Models
{
    public sealed record CreateEntryRequest
    {
        public Amount Amount { get; set; }
        public string Note { get; set; }
        public Guid? CatageoryId { get; set; }
        public EntryKind Kind { get; set; }
        public Guid AccountId { get; set; }
    }
}
