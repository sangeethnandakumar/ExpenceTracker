namespace Presentation.Models
{
    public sealed record CreateEntryRequest
    {
        public float Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
