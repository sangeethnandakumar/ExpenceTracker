using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class InvalidLoginException : LoginException
    {
        public InvalidLoginException(string username) : base($"Invalid username: {username}")
        {
        }
    }
}
