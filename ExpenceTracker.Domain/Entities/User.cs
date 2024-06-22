using Domain.Enums;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class User : Entity
    {
        private User() { }

        public static User Create(string firstName, string lastName, string email, LogInMode loginMode, string password, DateOnly? dateOfBirth, Gender gender, string? country, string? avatar)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return new User(
                new Name(firstName, lastName),
                new Credential(loginMode, email, hashedPassword),
                dateOfBirth,
                gender,
                country,
                avatar);
        }

        private User(Name name, Credential credential, DateOnly? dateOfBirth, Gender gender, string? country, string? avatar) : base(Guid.NewGuid())
        {
            Name = name;
            Credential = credential;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Avatar = avatar;
        }

        public Name Name { get; private set; }
        public Credential Credential { get; private set; }
        public string? Country { get; private set; }
        public Gender Gender { get; private set; }
        public DateOnly? DateOfBirth { get; private set; }
        public string? Avatar { get; private set; }
    }
}
