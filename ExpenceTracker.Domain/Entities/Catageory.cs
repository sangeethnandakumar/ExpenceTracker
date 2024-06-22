using Domain.Primitives;

namespace Domain.Entities
{

    public sealed class Catageory : Entity
    {
        private Catageory() { }

        public Catageory(string name, string icon, bool isBuiltIn, string description, Guid? accountId, Guid? parentCatageory) : base(Guid.NewGuid())
        {
            Name = name;
            Icon = icon;
            IsBuiltIn = isBuiltIn;
            Description = description;
            AccountId = accountId;
            ParentCatageory = parentCatageory;
        }

        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? Icon { get; private set; }
        public bool IsBuiltIn { get; private set; }
        public Guid? ParentCatageory { get; private set; }
        public Guid? AccountId { get; private set; }
    }
}
