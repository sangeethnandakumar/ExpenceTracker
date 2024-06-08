using Domain.Enums;
using Domain.Primitives;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public sealed class Entry : Entity
    {
        public Amount Amount { get; private set; }
        public string Note { get; private set; }
        public Guid? CatageoryId { get; private set; }
        public EntryKind Kind { get; private set; }
        public Guid AccountId { get; private set; }

        public Entry(Amount amount, Guid userId) : base(Guid.NewGuid())
        {
            Amount = amount;
            AccountId = userId;
        }

        public Entry()
        {

        }
    }
}
