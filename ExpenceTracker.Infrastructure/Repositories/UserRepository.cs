using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Users;
using LanguageExt.Common;

namespace Infrastructure.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        public Result<Guid> CreateUser(User user)
        {
            return new Result<Guid>(new InvalidLoginException(user.Username));
        }

        public Result<Guid> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Result<Guid> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
