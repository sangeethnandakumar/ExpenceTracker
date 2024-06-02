using Domain.Users;
using LanguageExt.Common;

namespace Domain.Abstractions
{
    public interface IUserRepository
    {
        Result<Guid> CreateUser(User user);
        Result<Guid> UpdateUser(User user);
        Result<Guid> DeleteUser(User user);
    }
}
