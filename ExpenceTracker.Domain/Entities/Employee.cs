using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Employee : Entity
    {
        //Private Contructor for EFCore
        private Employee() { }

        //Contructor
        public Employee(string name, bool isDeveloper, int age, DateTime dob) : base(Guid.NewGuid())
        {
            Name = name;
            IsDeveloper = isDeveloper;
            Age = age;
            Dob = dob;
        }

        //Immutable Props
        public string Name { get; private set; }
        public bool IsDeveloper { get; private set; }
        public int Age { get; private set; }
        public DateTime Dob { get; private set; }
    }
}
