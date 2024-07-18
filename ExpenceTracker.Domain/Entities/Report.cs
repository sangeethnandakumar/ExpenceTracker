using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Report : Entity
    {
        //Private Contructor for EFCore
        private Report() { }

        //Contructor
        public Report(DateTime start, DateTime end, int total, List<object> breakdown) : base(Guid.NewGuid())
        {
            Start = start;
            End = end;
            Total = total;
            Breakdown = breakdown;
        }

        //Immutable Props
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int Total { get; private set; }
        public List<object> Breakdown { get; private set; }
    }
}
