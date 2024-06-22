using Domain.Enums;

namespace Presentation.Models
{
    public record CreateUserRequest(
       string FirstName,
       string LastName,
       string Email,
       LogInMode LogInMode,
       DateOnly? DateOfBirth,
       string Avatar,
       Gender Gender,
       string Country,
       string Password
   );

}
