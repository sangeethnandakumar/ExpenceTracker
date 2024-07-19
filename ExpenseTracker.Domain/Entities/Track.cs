using Domain.Primitives;

namespace Domain.Entities
{

    public sealed class Track : Entity
    {
        //Private Contructor for EFCore
        private Track() { }

        //Contructor
        public Track(DateTime date, int exp, int inc, string notes, Guid category) : base(Guid.NewGuid())
        {
            Date = date;
            Exp = exp;
            Inc = inc;
            Notes = notes;
            Category = category;
        }

        //Immutable Props
        public DateTime Date { get; private set; }
        public int Exp { get; private set; }
        public int Inc { get; private set; }
        public string Notes { get; private set; }
        public Guid Category { get; private set; }
    }
}
