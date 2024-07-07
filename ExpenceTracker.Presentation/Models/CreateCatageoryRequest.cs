namespace Presentation.Models
{

    public sealed record CreateCatageoryRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public bool IsBuiltIn { get; set; }
        public Guid? ParentCatageory { get; set; }
        public Guid? AccountId { get; set; }
    }
}
