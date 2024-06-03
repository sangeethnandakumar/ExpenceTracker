namespace Presentation.Entry.Models
{
    public sealed record EntryRequest
    {
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
