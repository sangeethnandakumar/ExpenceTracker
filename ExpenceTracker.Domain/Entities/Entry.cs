﻿using Domain.Primitives;
using Domain.ValueTypes;

namespace Domain.Entities
{
    public sealed class Entry : Entity
    {
        public Amount Amount { get; private set; }
        public Guid UserId { get; private set; }
        public Entry(Amount amount, Guid userId) : base(Guid.NewGuid())
        {
            Amount = amount;
            UserId = userId;
        }
    }
}
