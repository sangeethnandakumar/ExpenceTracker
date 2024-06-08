using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Catageory : Entity
    {
        public Catageory()
        {
            
        }

        public Catageory(string name, string icon, bool isBuiltIn, string description, Guid accountId) : base(Guid.NewGuid())
        {
            Name = name;
            Icon = icon;
            IsBuiltIn = isBuiltIn;
            Description = description;
            AccountId = accountId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Icon { get; private set; }
        public bool IsBuiltIn { get; private set; }
        public Guid AccountId { get; private set; }
    }
}
