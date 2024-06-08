namespace Presentation.Entry.Models
{
    public sealed record CreateCatageoryRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
