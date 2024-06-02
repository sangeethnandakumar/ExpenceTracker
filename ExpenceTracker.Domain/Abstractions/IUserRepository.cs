using Domain.Users;

namespace Domain.Abstractions
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        Guid UpdateUser(User user);
        Guid DeleteUser(User user);
    }
}
