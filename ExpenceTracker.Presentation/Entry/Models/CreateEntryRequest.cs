namespace Presentation.Entry.Models
{
    public sealed record CreateEntryRequest
    {
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
