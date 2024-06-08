using Domain.Enums;
using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class User : Entity
    {
        public User(string firstName, string lastName, DateTime? dOB, Gender gender, string country, string email) : base(Guid.NewGuid())
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dOB;
            Gender = gender;
            Country = country;
            Email = email;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime? DOB { get; private set; }
        public Gender Gender { get; private set; }
        public string Country { get; private set; }
    }
}
