using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Entry : Entity
    {
        public Amount Amount { get; private set; }
        public string Note { get; private set; }
        public Guid? CatageoryId { get; private set; }
        public EntryKind Kind { get; private set; }
        public Guid AccountId { get; private set; }

        private Entry() { }

        public Entry(Amount amount, string note, Guid? catageoryId, EntryKind kind, Guid accountId) : base(Guid.NewGuid())
        {
            Amount = amount;
            Note = note;
            CatageoryId = catageoryId;
            Kind = kind;
            AccountId = accountId;
        }
    }
}
