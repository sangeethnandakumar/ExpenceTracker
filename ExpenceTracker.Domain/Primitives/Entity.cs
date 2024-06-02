namespace Domain.Primitives
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime? CreatedOn { get; protected set; }
        public DateTime? UpdatedOn { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }

        protected Entity(Guid id)
        {
            Id = id;
            CreatedOn = DateTime.UtcNow;
        }
    }
}
