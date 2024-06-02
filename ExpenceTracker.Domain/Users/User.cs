using Domain.Enums;
using Domain.Primitives;

namespace Domain.Users
{
    public sealed class User : Entity
    {
        public User(string firstName, string? lastName, string username, DateTime? dateOfBirth, LoginMethod loginMethod, Gender? gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            HashedPassword = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            DateOfBirth = dateOfBirth;
            LoginMethod = loginMethod;
            Gender = gender;
        }

        public string FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Username { get; private set; }
        public string HashedPassword { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public LoginMethod LoginMethod { get; private set; }
        public Gender? Gender { get; private set; }
    }
}
